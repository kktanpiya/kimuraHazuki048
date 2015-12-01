using System;
using PI1M_Dashboard.Lib.DLayer.SQLite;

namespace PI1M_Dashboard
{
	public class DatabaseTables
	{
		public DatabaseTables ()
		{
		}
			
	}

	public class UserSettings
	{
		public UserSettings () { }
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string settingsCode { get; set; }
		public string settingsName { get; set; }
		public bool settingsChecked1Boolean { get; set; }
		public bool settingsChecked2Boolean { get; set; }
		public bool settingsChecked3Boolean { get; set; }
		public bool settingsChecked4Boolean { get; set; }
		public bool settingsChecked5Boolean { get; set; }
		public string settingsSpinner1Value { get; set; }
		public string settingsSpinner2Value { get; set; }
		public string settingsSpinner3Value { get; set; }
		public string settingsSpinner4Value { get; set; }
		public string settingsSpinner5Value { get; set; }
	}

	public class MMenu_LoginInfo
	{
		public MMenu_LoginInfo () { }
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string li_userid { get; set; }
		public string li_username { get; set; }
		public string li_email { get; set; }
		public string li_fullname { get; set; }
		public string li_sitename { get; set; }
		public string li_sitecode { get; set; }
		public string li_siteid { get; set; }
		public string li_icno { get; set; }
		public string li_dashtoken { get; set; }
		public string li_loginstate { get; set; }
	}

	public class MySoal_SentItems
	{
		public MySoal_SentItems () { }

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string si_from { get; set; }
		public string si_to { get; set; }
		public string si_subject { get; set; }
		public string si_content { get; set; }
		public string si_sentAt { get; set; }

	}

}

