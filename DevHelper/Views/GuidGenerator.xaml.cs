using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DevHelper.Models;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace DevHelper.Views
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class GuidGenerator : Page
  {
    private List<GuidGeneratorTemplate> TemplateItemSource;

    public GuidGenerator()
    {
      SetTemplateItemSource();
      this.InitializeComponent();
      
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      CoreWindow.GetForCurrentThread().KeyDown += MainPare_KeyDown;
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      CoreWindow.GetForCurrentThread().KeyDown -= MainPare_KeyDown;
    }

    private void MainPare_KeyDown(CoreWindow sender, KeyEventArgs args)
    {
      if (args.VirtualKey == VirtualKey.Enter)
      {
        GenerateGuids();
      }
    }

    private void SetTemplateItemSource()
    {
      TemplateItemSource = new List<GuidGeneratorTemplate>
      {
        null,
        new GuidGeneratorTemplate()
        {
          Name = "C# - Guid.Parse()",
          Prefix = "Guid.Parse(\"",
          Suffix = "\")",
          Separator = ","
        }
      };


    }

    private void GenerateGuidsTapped(object sender, TappedRoutedEventArgs e)
    {
      GenerateGuids();
    }

    private void GenerateGuids()
    {
      var guids = "";
      var prefix = TextBoxPrefix.Text;
      var suffix = TextBoxSuffix.Text;
      var separator = TextBoxSeparator.Text;

      if (int.TryParse(TextBoxGuidsCount.Text, out int count))
      {
        for (int i = 0; i < count; i++)
        {
          //guids += $"Guid.Parse(\"{Guid.NewGuid()}\")";
          //if (i < count - 1)
          //  guids += $",{Environment.NewLine}";
          guids += $"{prefix}{Guid.NewGuid()}{suffix}";
          if (i < count - 1)
            guids += $"{separator}{Environment.NewLine}";
        }
      }

      //TextBoxGeneratedGuids.Text = guids;
      TextBoxGeneratedGuids.Document.SetText(TextSetOptions.None, guids);
      if (CheckBoxCopyAuto.IsChecked.GetValueOrDefault(false))
      {
        var dataPackage = new DataPackage();
        dataPackage.SetText(guids);
        Clipboard.SetContent(dataPackage);
      }
    }

    private void SetSelectedTemplate(object selectedTemplate)
    {
      if (selectedTemplate == null)
      {
        Clear();
      }
      else
      {
        var selection = (GuidGeneratorTemplate) selectedTemplate;
        TextBoxSeparator.Text = selection.Separator;
        TextBoxPrefix.Text = selection.Prefix;
        TextBoxSuffix.Text = selection.Suffix;
      }
    }

    private void Clear()
    {
      TextBoxSeparator.Text = "";
      TextBoxPrefix.Text = "";
      TextBoxSuffix.Text = "";
    }

    private void ComboBoxTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      SetSelectedTemplate(((ComboBox)sender).SelectedItem);
    }
  }
}
