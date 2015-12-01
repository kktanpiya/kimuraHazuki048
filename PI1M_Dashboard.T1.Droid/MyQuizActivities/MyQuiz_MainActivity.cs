using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using DataAccess;
using MyQuiz;
using Android.Telephony;
using PI1M_Dashboard.T1.Droid;
using Newtonsoft.Json;
using Android.Preferences;
using Android.Content.Res;
using Android.Support.Design.Widget;
using Android.Views.InputMethods;
using System.Threading.Tasks;
using Android.Content.PM;
using Android.Provider;
using Android.Graphics;

namespace MyQuiz
{
	[Activity (Label = "", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MyQuiz_MainActivity : Activity
	{
		int completionStat;
		int drawNo;
		string uid;

		public static Button btn_send;
		EditText et_eventCode;
		//TextView tv_message;
		Android.Widget.ProgressBar pb;

		string event_code; 
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//Ask for action bar to show
			Window.RequestFeature (WindowFeatures.ActionBar);
			//Setup our action bar title and icon
			//ActionBar.Title = "MyQuiz ";

			SetContentView (Resource.Layout.MyQuiz_MainActivity);

			//user_id
			uid = Intent.GetStringExtra("UserID");
			Console.Error.WriteLine ("uid"+uid);



			//check for completion status
			try {
				QuizDB myquizDB = DB_access.getCompletionStat (uid);
				completionStat = myquizDB.completion_Stat;
				drawNo = myquizDB.draw_No;
			} catch {
			
			}

			//if completionStat true, display lucky number
			if (completionStat == 1) {
				Finish ();
				var activity2 = new Intent (this, typeof(ShowDrawCode));
				activity2.PutExtra ("drawNo", drawNo);
				StartActivity (activity2);
			}


			et_eventCode = FindViewById<EditText> (Resource.Id.editText_kod);
			btn_send = FindViewById<Button> (Resource.Id.btnmasuk_kod);
			//tv_message = FindViewById<TextView> (Resource.Id.tv_errorMsg);
			pb = FindViewById<Android.Widget.ProgressBar> (Resource.Id.progress_bar);
			pb.Visibility = ViewStates.Gone;

			btn_send.Click += async delegate {

				//show loading and hide send button
				pb.Visibility = ViewStates.Visible;
				btn_send.Visibility = ViewStates.Invisible;

				//get event code from user input
				event_code = et_eventCode.Text;

				//close keyboard
				InputMethodManager inputManager = (InputMethodManager) this.GetSystemService(Context.InputMethodService);
				inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

				//check if user enter event code
			   if(event_code.Length != 0)
			   {
					var isOnline = await Task.Factory.StartNew(() => Commonlib.IsOnline (this, Commonlib.dontCloseActivity));

					if (isOnline == true)
					{
						ClickFunction();
					}
					else
					{
						//hide loading and show send button
						pb.Visibility = ViewStates.Invisible;
						btn_send.Visibility = ViewStates.Visible;
					}
			   }
			   else
			   {
					Snackbar snackbar = Snackbar
						.Make(btn_send,"Sila masukkan kod penyertaan.",Snackbar.LengthLong)
						.SetAction("OK",delegate {});

					View snackbarView = snackbar.View;
					TextView tv = (TextView)snackbarView.FindViewById(Resource.Id.snackbar_text);
					tv.SetTextColor(Color.White);
										
					snackbar.Show();
					
					//hide loading and show send button
					pb.Visibility = ViewStates.Invisible;
					btn_send.Visibility = ViewStates.Visible;

			   }

			};
		}
				
		private async void ClickFunction()
		{

			//get imei
			var telephonyManager = (TelephonyManager) GetSystemService(TelephonyService);
			string imei = telephonyManager.DeviceId;

			//if no imei use androidid
			if (String.IsNullOrEmpty (imei)) {
				imei = Settings.Secure.GetString (ContentResolver,Settings.Secure.AndroidId);
			}

			Console.Error.WriteLine ("imei:"+imei);

			//if imei not empty proceed
			if (!String.IsNullOrEmpty (imei)) {
				try {	
					var json_validateEventCode = await Task.Factory.StartNew (() => Webservice.ws_validateEventCode (et_eventCode.Text, imei, uid));
				
					//hide loading and show send button
					pb.Visibility = ViewStates.Invisible;
					btn_send.Visibility = ViewStates.Visible;

					//var json_validateEventCode = Webservice.ws_validateEventCode (et_eventCode.Text, imei, uid);
					Console.Error.WriteLine (json_validateEventCode);
					Webservice.validateEventCode data = JsonConvert.DeserializeObject<Webservice.validateEventCode> (json_validateEventCode);


					if (data.success == 1) {

						//disable button to prevent double click
						RunOnUiThread (() => {
							btn_send.Enabled = false;
						});

						//database save quizdata
						QuizDB quizDB = new QuizDB ();
						quizDB.completion_Stat = 0;
						quizDB.event_Code = event_code;
						quizDB.ic_No = uid;
						quizDB.event_Id = data.event_id;

						try {
							DB_access.saveData (quizDB);
						} catch {

						}


						//loop and store question and answer into list
						foreach (var temp in data.quizs) {
							if (temp.answer == 0) {
								QuestionAnswer.answerList.Add (false);
							} else {
								QuestionAnswer.answerList.Add (true);
							}

							QuestionAnswer.questionList.Add (temp.question);
						}

						//tv_message.Visibility = ViewStates.Invisible;

						Bundle msg = new Bundle ();
						msg.PutInt ("currentQuestion", 1);
						msg.PutBoolean ("anwser", QuestionAnswer.answerList [0]);
						msg.PutString ("user_id", uid);
						msg.PutInt ("event_id", data.event_id);
						msg.PutString ("imei", imei);

						FragmentTransaction transaction = FragmentManager.BeginTransaction ();
						dialog_Signup signUpDialog = new dialog_Signup ();
						signUpDialog.Arguments = msg;
						signUpDialog.Cancelable = false;
						signUpDialog.Show (transaction, "dialog fragment");

					} else if (data.success == 0) {

						Snackbar snackbar = Snackbar
						.Make (btn_send, "Kod penyertaan salah. Sila semak semula.", Snackbar.LengthLong)
						.SetAction ("OK", delegate {
						});

						View snackbarView = snackbar.View;
						TextView tv = (TextView)snackbarView.FindViewById (Resource.Id.snackbar_text);
						tv.SetTextColor (Color.White);

						snackbar.Show ();
					} else if (data.success == 3) {
						AlertDialog.Builder alert = new AlertDialog.Builder (this);

						alert.SetTitle ("Quiz telah ditutup!");
						alert.SetCancelable (false);
						alert.SetPositiveButton ("OK", (senderAlert, args) => {
							Finish ();
						});

						RunOnUiThread (() => {
							alert.Show ();
						});
					} else if (data.success == 2) {
						Snackbar snackbar = Snackbar
						.Make (btn_send, "Hanya satu penyertaan bagi setiap akaun/gajet", Snackbar.LengthLong)
						.SetAction ("OK", delegate {
						});

						View snackbarView = snackbar.View;
						TextView tv = (TextView)snackbarView.FindViewById (Resource.Id.snackbar_text);
						tv.SetTextColor (Color.White);

						snackbar.Show ();
					}
				} catch (Exception ex) {
					Console.Error.WriteLine ("ex" + ex);
					AlertDialog.Builder alert = new AlertDialog.Builder (this);

					alert.SetTitle ("Ralat! Sila cuba sebentar lagi. ");
					alert.SetCancelable (false);
					alert.SetPositiveButton ("OK", (senderAlert, args) => {
					});

					RunOnUiThread (() => {
						alert.Show ();
					});


					//hide loading and show send button
					pb.Visibility = ViewStates.Invisible;
					btn_send.Visibility = ViewStates.Visible;
				}
			} else {

				Snackbar snackbar = Snackbar
					.Make (btn_send, "Ralat! Gajet anda tiada imei/androidid", Snackbar.LengthLong)
					.SetAction ("OK", delegate {
					});

				View snackbarView = snackbar.View;
				TextView tv = (TextView)snackbarView.FindViewById (Resource.Id.snackbar_text);
				tv.SetTextColor (Color.White);

				snackbar.Show ();
			}
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			return true;
		}
	}

	public class dialog_Signup : DialogFragment
	{
		RelativeLayout rl_betul;
		RelativeLayout rl_salah;
		RelativeLayout rl_soalanTamat;

		RadioButton radioButtonSalah;
		RadioButton radioButtonBetul;

		Button btn_tryAgain;
		Button btn_nextQuestion;
		Button btn_soalanTamat;
		ImageButton btn_Close;

		TextView tv_QuestionNo;
		TextView tv_QuestionIndicator;
		TextView tv_Question;


		bool anwser;
		int currentQuestion;
		static string user_id;
		static int event_id;
		static string imei;

		Android.Widget.ProgressBar pb;
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.Main2, container, false);

			radioButtonSalah = view.FindViewById<RadioButton> (Resource.Id.radioButtonSalah);
			radioButtonBetul = view.FindViewById<RadioButton> (Resource.Id.radioButtonBetul);
		    rl_betul = view.FindViewById<RelativeLayout> (Resource.Id.rl_betul);
			rl_salah = view.FindViewById<RelativeLayout> (Resource.Id.rl_salah);
			rl_soalanTamat = view.FindViewById<RelativeLayout> (Resource.Id.rl_soalanTamat);

			btn_tryAgain = view.FindViewById<Button> (Resource.Id.btn_tryAgain);
			btn_nextQuestion = view.FindViewById<Button> (Resource.Id.btn_nextQuestion);
			btn_soalanTamat = view.FindViewById<Button> (Resource.Id.btn_soalanTamat);
			btn_Close = view.FindViewById<ImageButton> (Resource.Id.btn_Close);

			tv_QuestionNo = view.FindViewById<TextView> (Resource.Id.tv_QuestionNo);
			tv_QuestionIndicator = view.FindViewById<TextView> (Resource.Id.tv_QuestionIndicator);
			tv_Question = view.FindViewById<TextView> (Resource.Id.tv_Question);


			pb = view.FindViewById<Android.Widget.ProgressBar> (Resource.Id.progressbar_submitquiz);
			pb.Visibility = ViewStates.Gone;

			//get value from main
			currentQuestion = Arguments.GetInt ("currentQuestion");
			anwser = Arguments.GetBoolean ("anwser");


			//only get value if question is 1 (from main)
			if (currentQuestion == 1) {
				Console.Error.WriteLine(user_id = Arguments.GetString ("user_id"));
				Console.Error.WriteLine(event_id = Arguments.GetInt ("event_id"));
				Console.Error.WriteLine(imei = Arguments.GetString ("imei"));
			}

			tv_QuestionNo.Text = String.Format("Soalan {0} :",currentQuestion);
			tv_QuestionIndicator.Text = String.Format("{0}/{1}", currentQuestion, QuestionAnswer.questionList.Count);
			tv_Question.Text = QuestionAnswer.questionList[currentQuestion - 1];

			radioButtonSalah.Click += RButtonSalah_Click;
			radioButtonBetul.Click += RButtonBetul_Click;
			btn_tryAgain.Click += btnTryAgain_Click;
			btn_nextQuestion.Click += btnNextQuestion_Click;


			//close quiz
			btn_Close.Click += btnClose_Click;

			return view;
		}

		void btnClose_Click (object sender, EventArgs e)
		{

			var context = Activity;

			AlertDialog.Builder builder = new AlertDialog.Builder (context);
			AlertDialog alertDialog = builder.Create ();
			alertDialog.SetTitle ("Tutup Quiz");
			alertDialog.SetMessage ("Anda pasti?");

			alertDialog.SetButton ("Ya", (s, ev) => {
				Dismiss ();
				QuestionAnswer.questionList.Clear();
				QuestionAnswer.answerList.Clear();

				context.RunOnUiThread (() => {
					MyQuiz_MainActivity.btn_send.Enabled = true;
				});
			});

			alertDialog.SetButton2 ("Tidak", (s, ev) => {
			});

			alertDialog.Show ();
		}

		private void RButtonSalah_Click (object sender, EventArgs e)
		{
			if (currentQuestion < QuestionAnswer.questionList.Count) {
				if (anwser == true) {
					rl_salah.Visibility = ViewStates.Visible;
					radioButtonBetul.Enabled = false;
					rl_betul.Visibility = ViewStates.Invisible;
					radioButtonBetul.Checked = false;
				} else {
					rl_betul.Visibility = ViewStates.Visible;
					radioButtonBetul.Enabled = false;
					rl_salah.Visibility = ViewStates.Invisible;
					radioButtonBetul.Checked = false;
				}
			}
			else if(currentQuestion == QuestionAnswer.questionList.Count)
			{
				if (anwser == true) {
					rl_salah.Visibility = ViewStates.Visible;
					radioButtonBetul.Enabled = false;
					rl_betul.Visibility = ViewStates.Invisible;
					radioButtonBetul.Checked = false;
				} else {
					rl_soalanTamat.Visibility = ViewStates.Visible;
					radioButtonBetul.Enabled = false;
					rl_salah.Visibility = ViewStates.Invisible;
					radioButtonBetul.Checked = false;

					btn_soalanTamat.Click += delegate {
						endQuiz();
					};
				}
			
			}
		}

		private void RButtonBetul_Click (object sender, EventArgs e)
		{
			Console.Error.WriteLine ("total"+QuestionAnswer.questionList.Count);
			if (currentQuestion < QuestionAnswer.questionList.Count) {
				if (anwser == true) {
					rl_betul.Visibility = ViewStates.Visible;
					radioButtonSalah.Enabled = false;
					rl_salah.Visibility = ViewStates.Invisible;
					radioButtonSalah.Checked = false;

				} else {
					rl_salah.Visibility = ViewStates.Visible;
					radioButtonSalah.Enabled = false;
					rl_betul.Visibility = ViewStates.Invisible;
					radioButtonSalah.Checked = false;

				}
			} 
			else if(currentQuestion == QuestionAnswer.questionList.Count) 
			{
				if (anwser == true) {
					rl_soalanTamat.Visibility = ViewStates.Visible;
					radioButtonSalah.Enabled = false;
					rl_salah.Visibility = ViewStates.Invisible;
					radioButtonSalah.Checked = false;

					btn_soalanTamat.Click += delegate {
						endQuiz();
					};

				} else {
					rl_salah.Visibility = ViewStates.Visible;
					radioButtonSalah.Enabled = false;
					rl_betul.Visibility = ViewStates.Invisible;
					radioButtonSalah.Checked = false;

				}	
			}
		}

		private async void endQuiz()
		{
			pb.Visibility = ViewStates.Visible;
			btn_soalanTamat.Visibility = ViewStates.Invisible;

			var context = Activity;

			var isOnline = await Task.Factory.StartNew(() => Commonlib.IsOnline (context, Commonlib.dontCloseActivity));

			if (isOnline == true) {

				try {
					
					var json_submitQuiz = await Task.Factory.StartNew (() => Webservice.ws_submitQuiz (event_id, user_id, imei));
		
					Console.Error.WriteLine (json_submitQuiz);

					Webservice.submitQuiz data = JsonConvert.DeserializeObject<Webservice.submitQuiz> (json_submitQuiz);
					Console.Error.WriteLine ("data" + data);

					if (IsAdded) {
						context.Finish ();
						var activity2 = new Intent (context, typeof(ShowDrawCode));
						activity2.PutExtra ("drawNo", data.luckyNo);
						activity2.PutExtra ("user_id", user_id);
						activity2.PutExtra ("animate", true);

						StartActivity (activity2);
						Dismiss ();

						//update lucky code into db
						DB_access.updateCompletionStat (data.luckyNo, user_id);

					}
				} catch (Exception ex){
					Console.Error.WriteLine ("ex"+ex);
					AlertDialog.Builder alert = new AlertDialog.Builder (context);

					alert.SetTitle ("Ralat! Sila cuba sebentar lagi.");
					alert.SetCancelable (false);
					alert.SetPositiveButton ("OK", (senderAlert, args) => {
					});

					context.RunOnUiThread (() => {
						alert.Show ();
					});
				}
			} else {
				pb.Visibility = ViewStates.Invisible;
				btn_soalanTamat.Visibility = ViewStates.Visible;

			}

			//clear array quiz,question
			QuestionAnswer.answerList.Clear();
			QuestionAnswer.questionList.Clear();

		}


		private void btnTryAgain_Click (object sender, EventArgs e)
		{
			rl_salah.Visibility = ViewStates.Invisible;
			radioButtonSalah.Enabled = true;
			radioButtonBetul.Enabled = true;
			rl_betul.Visibility = ViewStates.Invisible;
			radioButtonSalah.Checked = false;
			radioButtonBetul.Checked = false;
		}

		private void btnNextQuestion_Click (object sender, EventArgs e)
		{
			Dismiss ();

			if (currentQuestion <= (QuestionAnswer.questionList.Count-1)) {
				Bundle msg = new Bundle ();
				msg.PutInt ("currentQuestion", currentQuestion + 1);
				msg.PutBoolean ("anwser", QuestionAnswer.answerList[currentQuestion]);

				FragmentTransaction transaction = FragmentManager.BeginTransaction ();
				dialog_Signup signUpDialog = new dialog_Signup ();
				signUpDialog.Arguments = msg;
				signUpDialog.Cancelable = false;
				signUpDialog.Show (transaction, "dialog fragment");
			}
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			//Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
		}

	}
}


