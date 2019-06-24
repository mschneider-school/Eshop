using System;
using System.Text;
using System.Xml;

namespace Eshop
{
    /// <summary>
    /// Vyuziti techniky dependency injection k logovani
    /// do souboru nebo do konzole (output view)
    /// </summary>
    interface ILog
    {
        void WriteLog(string message);
    }

    /// <summary>
    /// Trida pro zapis do souboru dedi od rozhrani ILog
    /// </summary>
    class FileLog : ILog
    {
        private static XmlWriter XmlWriter { get; set; }

        // vytvor xml soubor pouze jednou za behu probramu
        // pouzivej soubor k logovani vyuzitim volani statickych metod
        public FileLog()
        {
            if (XmlWriter == null)
            {
                XmlWriterSettings fileSettings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                };
                XmlWriter = XmlWriter.Create("../../../AppData/log.xml", fileSettings);
            }
        }

        /// <summary>
        /// Implementace metody pro zapis logu do souboru
        /// </summary>
        /// <param name="message">podle typu spravy se rozhodne akce</param>
        public void WriteLog(string message)
        {
            if (message.StartsWith("START"))
            {
                XmlWriter.WriteStartDocument();
                XmlWriter.WriteStartElement("session");
                XmlWriter.WriteStartElement("start");
                XmlWriter.WriteAttributeString("date", DateTime.Now.ToShortDateString());
                XmlWriter.WriteAttributeString("time", DateTime.Now.ToLongTimeString());
                XmlWriter.WriteEndElement();
                XmlWriter.WriteStartElement("orders");
            }
            else if (message.StartsWith("STOP"))
            {
                XmlWriter.WriteEndElement();
                XmlWriter.WriteStartElement("end");
                XmlWriter.WriteAttributeString("date", DateTime.Now.ToShortDateString());
                XmlWriter.WriteAttributeString("time", DateTime.Now.ToLongTimeString());
                XmlWriter.WriteEndElement();
                XmlWriter.WriteEndDocument();
                XmlWriter.Close();
            }
            else
            {
                ParseLogInput(message);
            }
        }

        /// <summary>
        /// Rozkouskovani spravy do elementu a zapis do logovaciho souboru
        /// </summary>
        /// <param name="message">sprava k rozkouskovani</param>
        private void ParseLogInput(string message)
        {    
            // message example:
            // 08/15/2019 12:28:13 Name Surname created order 256 in total 2500 CZK    
            string[] logValues = message.Split(' ');

            string date = logValues[0];
            string time = logValues[1];
            string author = $"{logValues[2]} {logValues[3]}";

            string state = logValues[4];
            string orderID = logValues[6];
            string sum = logValues[9];

            XmlWriter.WriteStartElement("order");
            XmlWriter.WriteAttributeString("id", orderID);
            XmlWriter.WriteAttributeString("sum", sum);
            XmlWriter.WriteAttributeString("state", state);
            XmlWriter.WriteAttributeString("author", author);

            XmlWriter.WriteStartElement("date");
            XmlWriter.WriteString(DateTime.Now.ToShortDateString());
            XmlWriter.WriteEndElement();

            XmlWriter.WriteStartElement("time");
            XmlWriter.WriteString(DateTime.Now.ToLongTimeString());
            XmlWriter.WriteEndElement();
            XmlWriter.WriteEndElement();
        }
    }

    /// <summary>
    /// Trida pro zapis do konzole dedi od rozhrani ILog
    /// </summary>
    class ConsoleLog : ILog
    {
        /// <summary>
        /// Implementace metody pro zapis logu do konzole
        /// </summary>
        /// <param name="message">sprava</param>
        public void WriteLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }

    /// <summary>
    /// Trida logger vyuziva rozhrani pro vyber metody zapisu
    /// metoda WriteLog z tridy FileLog, nebo ConsoleLog - podle volby uzivatele pri startu programu
    /// </summary>
    class Logger
    {
        private static ILog log;

        public static void Log(string message)
        {
            log.WriteLog(message);
        }

        /// <summary>
        /// Povoleni logovani do souboru
        /// Pozn.: pri startu aplikace volano z hl. formulare
        /// </summary>
        /// <param name="logToFile">povoleni logovani</param>
        public static void LogToFile(bool logToFile)
        {
            if (logToFile)
            {
                // pokud se uzivatel rozhodne logovat do souboru
                // vytvori se objekt FileLog (soucasne 1x logovaci soubor)
                log = new FileLog();
            }
            else
            {
                log = new ConsoleLog();
            }
        }

        /// <summary>
        /// Prevence vytvareni novych logovacich souboru pri dalsi instanci Logger tridy
        /// </summary>
        /// <returns>vraci true pokud je nastaveno logovani do souboru, jinak false</returns>
        public static bool IsFileLog()
        {
            // dalsi vytvorene FileLog objekty nevytvari nove log soubory
            if (log == new FileLog())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Signal pro start logovani pri logovani do souboru, do konzole pouze vpise START
        /// </summary>
        public static void StartLoggingSession()
        {
            log.WriteLog("START");
        }

        /// <summary>
        /// Signal pro konec logovani pri logovani do souboru, do konzole pouze vpise STOP
        /// </summary>
        public static void StopLoggingSession()
        {
            log.WriteLog("STOP");
        }

        /// <summary>
        /// Logovani nove vytvorene objednavky
        /// </summary>
        /// <param name="order">objednavka k zalogovani</param>
        public static void CreateOrderLog(Order order)
        {
            DateTime actualDateTime = DateTime.Now;

            log.WriteLog($"" +
                $"{actualDateTime.ToShortDateString()} " +
                $"{actualDateTime.ToShortTimeString()} " +
                $"{order.Customer.Name} {order.Customer.LastName} created order " +
                $"{order.ID} in total " +
                $"{order.FinalOrderPrice} CZK");
        }

        /// <summary>
        /// Logovani potvrzeni objednavky administratorem
        /// </summary>
        /// <param name="order">objednavka k zalogovani</param>
        public static void ConfirmOrderLog(Order order)
        {
            DateTime actualDateTime = DateTime.Now; 

            log.WriteLog($"" +
                $"{actualDateTime.ToShortDateString()} " +
                $"{actualDateTime.ToShortTimeString()} " +
                $"eshop admin confirmed order " +
                $"{order.ID} in total " +
                $"{order.FinalOrderPrice} CZK");
        }

        /// <summary>
        /// Logovani zruseni objednavky administratorem
        /// </summary>
        /// <param name="order">objednavka k zalogovani</param>
        public static void CancelOrderLog(Order order)
        {
            DateTime actualDateTime = DateTime.Now;

            log.WriteLog($"" +
                $"{actualDateTime.ToShortDateString()} " +
                $"{actualDateTime.ToShortTimeString()} " +
                $"eshop admin canceled order " +
                $"{order.ID} in total " +
                $"{order.FinalOrderPrice} CZK");
        }
    }
}
