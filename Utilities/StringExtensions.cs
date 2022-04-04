using System;

namespace Utilities
{
    public static class StringExtensions
    {
        public static string[] SplitByChar(this string source, char separator)
        {
            if (source is null)
            {
                return Array.Empty<string>();
            }
            return source.Split(separator);
        }
    }
}