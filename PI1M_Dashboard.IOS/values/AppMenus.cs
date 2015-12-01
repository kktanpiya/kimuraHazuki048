using System;
using System.Collections.ObjectModel;

namespace PI1M_Dashboard.IOS
{
	public class AppMenus
	{
		public AppMenus ()
		{
		}

		//Dashboard Big Menu
		public static ObservableCollection<BigMainMenuListItem> BigMainMenuLists = PopulateBigMainMenuLists();
			
		private static ObservableCollection<BigMainMenuListItem> PopulateBigMainMenuLists()
		{
			ObservableCollection<BigMainMenuListItem> BigMenuList = new ObservableCollection<BigMainMenuListItem> ();
			
			BigMenuList.Add (new BigMainMenuListItem () { 
				MenuTitle = Strings.SLMMyKomunitiString, 
				MenuSubTitle = "Sentuh untuk membuka aplikasi ini.", 
				MenuDesc = "Dapatkan maklumat masyarakat setempat disini." 
			});

			BigMenuList.Add (new BigMainMenuListItem () { 
				MenuTitle = Strings.SLMMySoalString, 
				MenuSubTitle = "Sentuh untuk membuka aplikasi ini.", 
				MenuDesc = "Sampaikan pertanyaan anda kepada Penguasa." 
			});
					
			BigMenuList.Add (new BigMainMenuListItem () { 
				MenuTitle = Strings.SLMMyHealthString, 
				MenuSubTitle = "Sentuh untuk membuka aplikasi ini.", 
				MenuDesc = "Maklumat berkenaan keadaan kesihatan anda." 
			});

			BigMenuList.Add (new BigMainMenuListItem () { 
				MenuTitle = Strings.SLMMySkoolString, 
				MenuSubTitle = "Sentuh untuk membuka aplikasi ini.", 
				MenuDesc = "Memberikan maklumat berkenaan perkembangan sekolah anak anda." 
			});

			BigMenuList.Add (new BigMainMenuListItem () { 
				MenuTitle = Strings.SLMMyShopString, 
				MenuSubTitle = "Sentuh untuk membuka aplikasi ini.", 
				MenuDesc = "Pelbagai barangan dan perkhidmatan tempatan untuk dijual." 
			});

			return BigMenuList;
		}

		//Left Side Menu
		public static ObservableCollection<MainMenuListItem> LeftSideMenuList = PopulateMainMenuList();

		private static ObservableCollection<MainMenuListItem> PopulateMainMenuList()
		{
			ObservableCollection<MainMenuListItem> MenuItems = new ObservableCollection<MainMenuListItem>();
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMDashboardString });
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMMyKomunitiString });
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMMySoalString });
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMMyHealthString });
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMMySkoolString });
			MenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMMyShopString });

			return MenuItems;
		}

		//Left Side Menu (Extended)
		public static ObservableCollection<MainMenuListItem> LeftSideMenuExList = PopulateMainMenuExList();

		private static ObservableCollection<MainMenuListItem> PopulateMainMenuExList()
		{
			ObservableCollection<MainMenuListItem> ExMenuItems = new ObservableCollection<MainMenuListItem>();
			ExMenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMExSettingsString });
			ExMenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMExAboutString });
			ExMenuItems.Add(new MainMenuListItem() { MenuTitleName = Strings.SLMExCommentString });

			return ExMenuItems;
		}
	}
}

