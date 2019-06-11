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
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(string message, string formName = null,
            string confirmButtonText = "Ano", string cancelButtonText = "Ne")
        {
            InitializeComponent();
            
            // osobitne nastavene udaje potvrzujiciho dialogu
            Name = formName;
            ConfirmationLabel.Text = message;
            ConfirmActionButton.Text = confirmButtonText;
            CancelActionButton.Text = cancelButtonText;
            CenterToParent();
        }
    }
}
