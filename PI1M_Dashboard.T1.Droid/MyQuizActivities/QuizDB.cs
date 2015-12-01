using SQLite;


namespace MyQuiz
{
	public class QuizDB
	{
		[PrimaryKey,AutoIncrement]
		public int id 
		{
			get;
			set;
		}

		public int event_Id
		{
			get;
			set;
		}

		public string ic_No 
		{
			get;
			set;
		}
		public string event_Code 
		{
			get;
			set;
		}

		public int completion_Stat 
		{
			get;
			set;
		}

		public int draw_No 
		{
			get;
			set;
		}
	}
}

