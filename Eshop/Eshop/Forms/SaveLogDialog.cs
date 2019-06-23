using System;
using System.Windows.Forms;

namespace Eshop
{
    public partial class SaveLogDialog : Form
    {
        public SaveLogDialog()
        {
            InitializeComponent();
            CenterToParent();
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
