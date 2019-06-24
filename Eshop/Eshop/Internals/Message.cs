using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Trida slouzi k vyvolani informacnich, varovnich, chybovych zprav v reakci na akce uzivatele
    /// </summary>
    class Message
    {
        /// <summary>
        /// Chybova zprava o zadani spatneho hesla administratora
        /// </summary>
        public static void InvalidPasswordWarning()
        {
            MessageBox.Show("Zadali jste špatné heslo, zkuste to prosím znovu.",
                "Nesprávné heslo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Chybova zprava o zadani spatnych prihlasovacich udaju zakaznika
        /// </summary>
        public static void InvalidCredentialsWarning()
        {
            MessageBox.Show("Zadali jste špatný email nebo heslo, zkuste to prosím znovu.",
                "Nesprávné údaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Chybove varovani o zadani spatneho formatu cisla do pole
        /// </summary>
        public static void QuantityFormatWarning()
        {
            MessageBox.Show("Údaj musí být zadán celým kladným číslem.", "Chyba formátu",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Chybove varovani o zadani nulove kvantity
        /// </summary>
        public static void NullQuantityWarning()
        {
            MessageBox.Show("Přidejte prosím alespoň jeden produkt.", "Špatný počet kusů",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Chybove varovani o nespravne zadanych udajech
        /// </summary>
        public static void InvalidEntriesWarning()
        {
            MessageBox.Show("Prosím opravte zvýrazněné chybně zadané údaje.",
                "Chybné údaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Chybova zprava pri registraci - email je jiz registrovan
        /// </summary>
        public static void EmailRegisteredWarning()
        {
            MessageBox.Show("Zadaný email je již registrovaný, zadejte prosím jiný email.",
                "Registrovaný email", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Informace o uspesne registraci
        /// </summary>
        public static void RegistrationSuccessInfo()
        {
            MessageBox.Show("Gratulujeme, registrace proběhla úspěšně!",
                "Úspěšná registrace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Informace o uspesne registraci v procesu objednavani
        /// </summary>
        public static void RegistrationToOrderSuccessInfo()
        {
            MessageBox.Show("Registrace proběhla úspěšně, teď se Vám zobrazí Vaše objednávka.",
                "Úspěšná registrace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Informace o prihlaseni uzivatele
        /// </summary>
        /// <param name="loggedIn">prihlaseny uzivatel</param>
        public static void LoginSuccessInfo(Customer loggedIn)
        {
            MessageBox.Show($"Přihlášení proběhlo úspěšně, vítejte zpět {loggedIn.Name}!",
                "Úspěšné přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Informace o uspesnem vytvoreni objednavky
        /// </summary>
        public static void CreatedOrderSuccesInfo()
        {
            MessageBox.Show($"Děkujeme, Vaše objednávka byla úspěšně vytvořena!",
                "Vytvoření objednávky", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Otazka na akci prihlaseni pod jinym uctem
        /// </summary>
        /// <returns>odpoved na prihlaseni pod jinym uctem</returns>
        public static DialogResult LoginNewCustomerQuestion()
        {
            return MessageBox.Show("Přejete si přihlásit se pod jiným zákazníckým účtem?", 
                "Přihlášení zákazníka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Informace o zmene stavu objednavky administratorem
        /// </summary>
        /// <param name="state">novy stav objednavky</param>
        public static void OrderStateChangeInfo(string state)
        {
            MessageBox.Show($"Objednávka byla {state}!",
                "Akce objednávky", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Overeni vyplneni udaju povinnych poli, oznaceni chybejicich udaju
        /// </summary>
        /// <param name="entryControls">kolekce elementu k validaci</param>
        /// <param name="color">chybova barva</param>
        /// <returns>true pokud jsou pole vyplnena, jinak false</returns>
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