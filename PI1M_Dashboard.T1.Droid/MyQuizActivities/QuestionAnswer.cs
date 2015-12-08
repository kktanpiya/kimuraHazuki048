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

		}
	}
}

