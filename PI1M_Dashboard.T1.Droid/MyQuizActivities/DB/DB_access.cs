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

		//get completionstatus
		public static QuizDB getCompletionStat(string id)
		{
			return me.db.getCompletionStat(id);
		}

		//save event_Code, user_id,event_Id
		public static int saveData (QuizDB quiz)
		{
			int stat = -1;

			stat = me.db.saveData (quiz);

			if (stat == 1) {
				Console.Error.WriteLine ("Success saved user_id: " + quiz.user_id);
			} else {
				Console.Error.WriteLine ("Failed saved user_id: " + quiz.user_id);
			}

			return stat;
		}

		//update completion status and drawcode
		public static int updateCompletionStat (int drawNo, string user_id)
		{
			int stat = -1;

			stat = me.db.updateCompletionStat (drawNo, user_id);

			return stat;
		}

		//delete db after event is completed
		public static int DeleteQuiz()
		{
			return me.db.DeleteQuiz();
		}
	}
}

