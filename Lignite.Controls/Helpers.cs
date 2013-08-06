using System.Globalization;
using System.Linq;

namespace Lignite.Controls
{
    public abstract class Helpers
    {
        /// <summary>
        /// Gets the currency symbol based on the region info for the current ISO 4217 currency code.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencySymbol(string currency)
        {
            if (currency == null) return "";
            if (currency == "") return "";

            var regionInfo = (from c in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures)
                              let r = new RegionInfo(c.LCID)
                              where r.ISOCurrencySymbol == currency
                              select r).First();

            if (regionInfo != null && regionInfo.CurrencySymbol != null)
            {
                return  regionInfo.CurrencySymbol;
            }

            return currency;
        }
    }
}
