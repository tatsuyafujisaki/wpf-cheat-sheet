using System;

namespace WpfCheatSheet.Common
{
    static class Bool
    {
        internal static bool EqIgnoreCase(string s1, string s2) => s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
    }
}
