using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using MyQuiz;

namespace DataAccess
{
	public class DB_query : SQLiteConnection
	{
		static object locker = new object ();

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "Quiz.db3";

				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;

				var path = Path.Combine (libraryPath, sqliteFilename);

				return path;	
			}
		}

		public DB_query (string path) : base (path)
		{
			// create the tables
			CreateTable<QuizDB> ();
		}

		public IEnumerable<QuizDB> GetStocks () 
		{
			lock (locker) {
				return (from i in Table<QuizDB> () select i).ToList ();
			}
		}

		public QuizDB getCompletionStat (string id)
		{
			lock (locker) {
				return Table<QuizDB>().FirstOrDefault(x => x.user_id == id);
			}
		}

		public int saveData (QuizDB item) 
		{
			lock (locker) 
			{
				return Insert (item);
			}
		}

		public int updateCompletionStat (int drawNo, string user_id) 
		{
			lock (locker) 
			{
				return Execute("UPDATE QuizDB set completion_Stat='1', draw_No='"+drawNo+"' where user_id='"+user_id+"'");
			}
		}

		public int DeleteQuiz() 
		{
			lock (locker) {
				try{
					return Execute("Delete from QuizDB");
				}
				catch(Exception ex) {
					return 0;
				}
			}
		}
	}
}