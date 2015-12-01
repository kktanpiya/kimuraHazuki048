using System;
using System.Collections.Generic;
using MyQuiz;

namespace DataAccess
{
	public class DB_access
	{
		DB_query db = null;
		protected static DB_access me;	
		static DB_access ()
		{
			me = new DB_access();
		}
		protected DB_access()
		{
			db = new DB_query(DB_query.DatabaseFilePath);
		}

		public static QuizDB getCompletionStat(string id)
		{
			return me.db.getCompletionStat(id);
		}

		public static IEnumerable<QuizDB> GetStocks ()
		{
			return me.db.GetStocks();
		}

		public static int saveData (QuizDB quiz)
		{
			int stat = -1;

			stat = me.db.saveData (quiz);

			if (stat == 1) {
				Console.Error.WriteLine ("Success saved IC No.: " + quiz.ic_No);
			} else {
				Console.Error.WriteLine ("Failed saved IC No.: " + quiz.ic_No);
			}

			return stat;
		}

		public static int updateCompletionStat (int drawNo, string icNo)
		{
			int stat = -1;

			stat = me.db.updateCompletionStat (drawNo, icNo);

			return stat;
		}

		public static int updateDrawNoEventID (QuizDB quiz)
		{
			int stat = -1;

//			stat = me.db.updateData (quiz);
//			Console.Error.WriteLine ("stat"+stat);
//			if (stat == 1) {
//				Console.Error.WriteLine ("Success update IC No.: " + quiz.ic_No + " Draw No: "+quiz.luckyDraw_no+" event ID: "+quiz.event_id);
//			} else {
//				Console.Error.WriteLine ("Failed update IC No.: " + quiz.ic_No + " Draw No: "+quiz.luckyDraw_no+" event ID: "+quiz.event_id);
//			}

			return stat;
		}

		public static int DeleteQuiz()
		{
			return me.db.DeleteQuiz();
		}
	}
}

