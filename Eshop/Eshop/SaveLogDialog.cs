using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Uvodni formular pro vyber metody logovani v programu
    /// </summary>
    public partial class SaveLogDialog : Form
    {
        public SaveLogDialog()
        {
            InitializeComponent();
        }

        private void FileOptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogToFile(true);
            Close();
        }

        private void ConsoleOptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogToFile(false);
            Close();
        }
    }
}
