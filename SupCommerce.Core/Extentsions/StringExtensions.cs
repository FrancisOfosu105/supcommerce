using System.Text.RegularExpressions;

namespace SupCommerce.Core.Extentsions
{
    public static class StringExtensions
    {
        public static string Slugify(this string text)
        {
            text = text.Trim();
            text = Regex.Replace(text, @"[^a-zA-Z0-9\s]", "");
            text = text.ToLower();
            text = Regex.Replace(text, @"[\s+]", "-");
            return text;
        }
    }
}