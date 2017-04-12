using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using DevHelper.Models;
using DevHelper.Views;

namespace DevHelper.ViewModels
{
  public class NavMenuVM
  {
    public readonly List<NavMenuListItem> NavMenuItems = new List<NavMenuListItem>();

    public NavMenuVM()
    {
      NavMenuItems.Add(new NavMenuListItem("../Assets/MenuIcons/Home-48_#666666.png", "Home", typeof(HomePage)));
      NavMenuItems.Add(new NavMenuListItem("../Assets/MenuIcons/Strichcode-48.png", "GUID Generator", typeof(GuidGenerator)));
      NavMenuItems.Add(new NavMenuListItem("../Assets/MenuIcons/Währungsumtausch-48.png", "GUID Converter", typeof(GuidConverter)));
    }
  }
}