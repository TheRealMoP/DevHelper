using System;
using System.Linq;
using System.Text;

namespace DevHelper.Extensions
{
  public static class SqliteFieldExtensions
  {

    public static string ToHexString(this Guid guid)
    {
      return guid.ToByteArray().ByteArrayToString();
    }

    public static string ToSqliteHexString(this Guid guid)
    {
      return $"x'{guid.ToByteArray().ByteArrayToString()}'";
    }

    #region Private

    private static string ByteArrayToString(this byte[] ba)
    {
      var hex = new StringBuilder(ba.Length * 2);

      for (int i = 0; i < ba.Length; i++) // <-- use for loop is faster than foreach   
        hex.Append(ba[i].ToString("X2")); // <-- ToString is faster than AppendFormat   

      return hex.ToString();
    }

    private static byte[] HexStringToByteArray(this string hex)
    {
      return Enumerable.Range(0, hex.Length)
                       .Where(x => x % 2 == 0)
                       .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                       .ToArray();
    }

    #endregion
  }
}