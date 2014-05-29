using System;

namespace NetExtentions
{
    public static class StringExtentions
    {
        public static Boolean ContainsIgnoreCase(this String aSource, String aValue)
        {
            return aSource != null && aSource.IndexOf(aValue, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        public static Boolean EqualsIgnoreCase(this String aSource, String aValue)
        {
            return (String.IsNullOrWhiteSpace(aSource) && String.IsNullOrWhiteSpace(aValue)) || aSource != null && aSource.Equals(aValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public static Boolean StartsWithIgnoreCase(this String aSource, String aValue)
        {
            return aSource != null && aSource.StartsWith(aValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public static Boolean EndsWithIgnoreCase(this String aSource, String aValue)
        {
            return aSource != null && aSource.EndsWith(aValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public static int IndexOfIgnoreCase(this String aSource, String aValue)
        {
            return aSource.IndexOf(aValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
