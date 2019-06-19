using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eshop
{
    class Validation
    {
        public static void InvalidPasswordWarning()
        {
            MessageBox.Show("Zadali jste špatné heslo, zkuste to prosím znovu.",
                "Nesprávné heslo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void InvalidCredentialsWarning()
        {
            MessageBox.Show("Zadali jste špatný email nebo heslo, zkuste to prosím znovu.",
                "Nesprávné údaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void QuantityFormatWarning()
        {
            MessageBox.Show("Údaj musí být zadán celým kladným číslem.", "Chyba formátu",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void NullQuantityWarning()
        {
            MessageBox.Show("Přidejte prosím alespoň jeden produkt.", "Špatný počet kusů",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void InvalidEntriesWarning()
        {
            MessageBox.Show("Prosím opravte zvýrazněné chybně zadané údaje.",
                "Chybné údaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void EmailRegisteredWarning()
        {
            MessageBox.Show("Zadaný email je již registrovaný, zadejte prosím jiný email.",
                "Registrovaný email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void RegistrationSuccessInfo()
        {
            MessageBox.Show("Registrace proběhla úspěšně, teď se Vám zobrazí Vaše objednávka.",
                "Úspěšná registrace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LoginSuccessInfo(Customer loggedIn)
        {
            MessageBox.Show($"Přihlášení proběhlo úspěšně, vítejte zpět {loggedIn.Name}!",
                "Úspěšné přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void CreatedOrderSuccesInfo()
        {
            MessageBox.Show($"Děkujeme, Vaše objednávka byla úspěšně vytvořena!",
                "Vytvoření objednávky", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult LoginNewCustomerQuestion()
        {
            return MessageBox.Show("Přejete si přihlásit se pod jiným zákazníckým účtem?", 
                "Přihlášení zákazníka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static bool InvalidEntriesCheck(List<Control> entryControls, Color color)
        {
            bool allValid = true;

            foreach (Control control in entryControls)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Parent.BackColor = color;
                    allValid = false;
                }
            }

            return allValid;
        }
    }
}
