using System;
using System.Reflection;
using System.Windows.Forms;

namespace Eshop
{
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dataGridView, bool setting)
        {
            Type dgvType = dataGridView.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dataGridView, setting, null);
        }
    }
}
