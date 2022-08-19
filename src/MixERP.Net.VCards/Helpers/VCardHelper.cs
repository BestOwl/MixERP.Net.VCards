using System.Text.RegularExpressions;
using System.Linq;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            MatchCollection matchCollection = Regex.Matches(contents, "((BEGIN:VCARD)(.*?)(END:VCARD))", RegexOptions.Singleline);
#if NETSTANDARD
            return matchCollection.Cast<Match>().Select(m => m.Value).ToArray();
#elif NET5_0_OR_GREATER
            return matchCollection.Select(m => m.Value).ToArray();
#else
#error This code block does not match csproj TargetFrameworks list
#endif
        }
    }
}