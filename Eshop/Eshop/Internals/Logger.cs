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
    /// Uziti patternu singleton pro vytvareni instance souboru
    /// pri pouziti property Instance
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

    class ConsoleLog : ILog
    {
        public void WriteLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }

    class Logger
    {
        private static ILog log;

        public static void Log(string message)
        {
            log.WriteLog(message);
        }

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

        public static bool IsFileLog()
        {
            // dalsi vytvorene FileLog objekty nevytvari nove log soubory
            if (log == new FileLog())
            {
                return true;
            }
            return false;
        }

        public static void StartLoggingSession()
        {
            log.WriteLog("START");
        }

        public static void StopLoggingSession()
        {
            log.WriteLog("STOP");
        }

        // zalogovani vytvoreni objednavky
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

        // zalogovani potvrzeni objednavky
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

        // zalogovani zruseni objednavky
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
