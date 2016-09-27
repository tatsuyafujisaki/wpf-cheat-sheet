using System.Windows.Forms;

namespace WpfUtil
{
    static class U
    {
        static Screen GetMouseScreen()
        {
            return Screen.FromPoint(Control.MousePosition);
        }
    }
}