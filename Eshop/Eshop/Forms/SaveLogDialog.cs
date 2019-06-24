using System;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Uvodni dialog volby zpusobu logovani
    /// Pozn.: predvolenym zpusobem je logovani do konzole
    /// </summary>
    public partial class SaveLogDialog : Form
    {
        public SaveLogDialog()
        {
            InitializeComponent();
            CenterToParent();
        }
    }
}
