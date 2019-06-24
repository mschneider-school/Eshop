using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Univerzalni formular slouzi k potvrzeni akce (napr. vymazani produktu)
    /// Text tlacitek "Ano" a "Ne", spravu a titulek okna lze nastavit konstruktorem
    /// </summary>
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(string message, string formName = null,
            string confirmButtonText = "Ano", string cancelButtonText = "Ne")
        {
            InitializeComponent();
            CenterToParent();
            
            // osobitne nastavene udaje potvrzujiciho dialogu
            Name = formName;
            ConfirmationLabel.Text = message;
            ConfirmActionButton.Text = confirmButtonText;
            CancelActionButton.Text = cancelButtonText;
        }
    }
}
