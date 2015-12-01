using SQLite;
using System.Collections.Generic;

namespace MyQuiz
{
	public class QuestionsAnwserDB
	{
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get;
			set;
		}

		public int EventId
		{
			get;
			set;
		}

		public string Question
		{
			get;
			set;
		}

		public bool Answer
		{
			get;
			set;
		}
	}
}

