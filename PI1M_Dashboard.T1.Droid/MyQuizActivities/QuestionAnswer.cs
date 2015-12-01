using System;
using System.Collections.Generic;
using SQLite;
using MyQuiz;
using System.Linq;
using DataAccess;

namespace MyQuiz
{
	public static class QuestionAnswer
	{
		public static List<bool> answerList = new List<bool> ();
		public static List<String> questionList = new List<String> ();

		static QuestionAnswer ()
		{
//			answerList.Add (false);
//			answerList.Add (true);
//			answerList.Add (false);
//			answerList.Add (false);
//			answerList.Add (true);
//
//			questionList.Add ("'Negaramu' ialah lagu kebangsaan Malaysia.");
//			questionList.Add ("Jumlah negeri di Malaysia ialah 13.");
//			questionList.Add ("Pi1M dashboard ialah aplikasi untuk memesan pizza secara atas talian.");
//			questionList.Add ("Alor Gajah terletak di negeri Johor.");
//			questionList.Add ("Melaka merupakan negeri yang mempunyai bilangan muzium terbanyak di Malaysia");
//								
//		
//			int eventID = 12;
//			long icNo =910910075275;
//			int eventCode = 101212;
//			int completionStat = 0;
//
//			QuizDB quizDB = new QuizDB ();
//			quizDB.event_Id = eventID;
//			quizDB.ic_No = icNo;
//			quizDB.event_Code = eventCode;
//			quizDB.completion_Stat = completionStat;
//


//			foreach (var qa in combine_quesAns) {
//				var q = new QuestionsAnwserDB { Question = qa.question, Answer = qa.answer, EventId = eventID };
//				conn.Insert(q);
//			}

//			foreach (var answer in answerList) {
//				var a = new QuestionsAnwserDB { Answer = answer };
//				conn.Insert(a);
//			}
		}
	}
}

