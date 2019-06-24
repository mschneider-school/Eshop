using System;
using System.Reflection;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Trida rozsireni. Obsahuje rozsireni pro podporu dvojiho nacteni nahledu (k zamezeni flickering)
    /// Zdroj: https://yuriyseniuk.blogspot.com/2010/11/how-to-increase-speed-of-datagridview.html
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Moznost aplikace nastaveni DoubleBuffered na dataGridView
        /// </summary>
        /// <param name="dgv">dataGridView instance ktery vola metodu</param>
        /// <param name="setting">nastaveni double bufferingu</param>
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
