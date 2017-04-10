using System;

namespace DevHelper.Models
{
  public class NavMenuListItem
  {
    public string IconSource { get; private set; }
    public string Caption { get; private set; }
    public Type Page { get; set; }

    public NavMenuListItem(string iconSource, string caption, Type page)
    {
      IconSource = iconSource;
      Caption = caption;
      Page = page;
    }
  }
}