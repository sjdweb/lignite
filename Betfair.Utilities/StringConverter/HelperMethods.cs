using System;

namespace Betfair.Utilities.StringConverter
{
    /// <summary>
    /// Convert complex Betfair response strings to objects
    /// </summary>
    internal class HelperMethods
    {
        internal static string ProtectBreakChars(string source)
        {
            source = source.Replace("\\:", "<COLON>");
            source = source.Replace("\\~", "<TILDA>");
            source = source.Replace("\\,", "<COMMA>");
            return source;
        }

        internal static string RestoreBreakChars(string source)
        {
            source = source.Replace("<COLON>", ":");
            source = source.Replace("<TILDA>", "~");
            source = source.Replace("<COMMA>", "\\,");
            return source;
        }

        /// <summary>
        /// Removes the tilde on the end i.e a~b~c~ will be a~b~c
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static string RemoveTrailingTilde(string source)
        {
            if (source.Length > 1)
            {
                if (source.Substring((source.Length - 1), 1) == "~")
                {
                    source = source.Remove((source.Length - 1), 1);
                }
            }
            return source;
        }

        /// <summary>
        /// Split a string into an int32 array
        /// </summary>
        /// <param name="splitChar"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static int?[] SplitToInt32Array(string splitChar, string source)
        {
            try
            {
                var temp = source.Split(splitChar.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int?[] response = new Nullable<int>[temp.Length];

                for (var i = 0; i < temp.Length; i++)
                    response[i] = Convert.ToInt32(temp[i]);

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}