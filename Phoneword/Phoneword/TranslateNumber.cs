using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Phoneword
{
    public static class TranslateNumber
    {
        public static string Translate(string text)
        {
            var result = string.Empty;
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.Trim().ToUpperInvariant();
                StringBuilder builder = new StringBuilder();

                foreach (char c in text)
                {
                    char? c2 = TranslateChar(c);
                    if (c2.HasValue)
                        builder.Append(c2.Value);
                }
                result = builder.ToString();
            }
            return result;
        }

        private static char? TranslateChar(char c)
        {
            char? result = null;

            if ("#*- 0123456789".Contains(c)) result = c;
            else if ("ABC".Contains(c)) result = '2';
            else if ("DEF".Contains(c)) result = '3';
            else if ("GHI".Contains(c)) result = '4';
            else if ("JKL".Contains(c)) result = '5';
            else if ("MNO".Contains(c)) result = '6';
            else if ("PQRS".Contains(c)) result = '7';
            else if ("TUV".Contains(c)) result = '8';
            else if ("WXYZ".Contains(c)) result = '9';

            return result;
        }
    }
}