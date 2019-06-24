namespace Eshop.DatabaseEntites
{
    /// <summary>
    /// Trida reprezentuje stav objednavky a slouzi k uchovani a manipulaci se stavem
    /// </summary>
    class OrderState
    {
        public const string TableName = "OrderState";
        public const string StateIDColumn = "StateID";
        public const string DescriptionColumn = "Description";

        public const int Built = 0;
        public const int Confirmed = 1;
        public const int Canceled = 2;
        public const int Sent = 3;

        public int ID { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Konstruktor stavu objednávky
        /// </summary>
        /// <param name="id">identifikacni cislo stavu objednavky</param>
        /// <param name="description">popis stavu objednavky</param>
        public OrderState(int id, string description)
        {
            ID = id;
            Description = description;
        }
    }
}
