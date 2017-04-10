using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using DevHelper.Extensions;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace DevHelper.Views
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class GuidConverter : Page
  {
    public GuidConverter()
    {
      this.InitializeComponent();
    }
    

    private  void ButtonConvertTapped(object sender, TappedRoutedEventArgs e)
    {
      Convert();
    }

    private async void Convert()
    {
      try
      {
        var inputAsGuid = Guid.Parse(TextBoxSource.Text);
        var sqLiteHexStr = inputAsGuid.ToSqliteHexString();
        var hexStr = inputAsGuid.ToHexString();
        var clipboardStr = "";

        TextBoxSqLiteHexString.Text = sqLiteHexStr;
        TextBoxHexString.Text = hexStr;

        if (CheckBoxCopySqlHexStrAuto.IsChecked.GetValueOrDefault(false) ||
            CheckBoxCopyHexStrAuto.IsChecked.GetValueOrDefault(false))
        {
          if (CheckBoxCopySqlHexStrAuto.IsChecked.GetValueOrDefault(false))
          {
            clipboardStr += sqLiteHexStr;
          }
          if (CheckBoxCopyHexStrAuto.IsChecked.GetValueOrDefault(false))
          {
            if (clipboardStr != "")
              clipboardStr += Environment.NewLine;
            clipboardStr += hexStr;
          }
          
          var dataPackage = new DataPackage();
          dataPackage.SetText(clipboardStr);
          Clipboard.SetContent(dataPackage);
        }
      }
      catch (FormatException ex)
      {
        var dlg =
          new MessageDialog("Eingegebene Zeichenkette ist keine gültige GUID" + "\r\n\r\n" + ex.InnerException?.Message)
          {
            Commands = { new UICommand("OK") { Id = 0} }
          };
        await dlg.ShowAsync();
      }
    }
  }
}
