namespace ITServices.Framework.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string Sanitize(this string strvalue)
        {
            return Regex.Replace(strvalue, @"<[^>]+>|&nbsp;", " ").Trim(); 
        }
    }
}