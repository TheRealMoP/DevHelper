using DevHelper.Models;
using DevHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DevHelper.Views;

namespace DevHelper
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    private NavMenuVM PageVM { get; set; }

    public MainPage()
    {
      this.InitializeComponent();
      PageVM = new NavMenuVM();
      (MainMenu.Content as Frame)?.Navigate(typeof(HomePage));
    }

    private void HamburgerButton_Click(object sender, RoutedEventArgs e)
    {
      MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
    }

    private void NavMenuOnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ListBox list = (ListBox)sender;
      if (list.SelectedIndex == -1) { return; }
      (MainMenu.Content as Frame)?.Navigate(((NavMenuListItem)list.SelectedItem)?.Page);
      MainMenu.IsPaneOpen = false;
    }
  }
}
