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
    public partial class SaveLogDialog : Form
    {
        private bool logChosen;
        public SaveLogDialog()
        {
            InitializeComponent();
        }

        private void FileOptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogToFile(true);
            logChosen = true;
            Close();
        }

        private void ConsoleOptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogToFile(false);
            logChosen = true;
            Close();
        }

        // formular se nezavre dokud nebyla zadana volba pro logovani
        private void SaveLogDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logChosen) e.Cancel = true;
        }
    }
}
