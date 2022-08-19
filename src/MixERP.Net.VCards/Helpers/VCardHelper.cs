using System.Text.RegularExpressions;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            MatchCollection matchCollection = Regex.Matches(contents, "((BEGIN:VCARD)(.*?)(END:VCARD))", RegexOptions.Singleline);
            return matchCollection.Select(m => m.Value).ToArray();
        }
    }
}