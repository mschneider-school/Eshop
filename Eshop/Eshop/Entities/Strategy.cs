namespace Eshop.DatabaseEntites
{
    /// <summary>
    /// Trida reprezentuje zaznam tabulky slevovych strategii v databazi
    /// </summary>
    class Strategy
    {
        public const string TableName = "Strategy";
        public const string StrategyIDCOlumn = "StrategyID";
        public const string DescriptionColumn = "Description";

        public int StrategyID { get; }
        public string Description { get; }

        /// <summary>
        /// Konstruktor slevove strategie
        /// </summary>
        /// <param name="strategyID">identifikacni cislo slevove strategie</param>
        /// <param name="description">popis slevove strategie</param>
        public Strategy(int strategyID, string description)
        {
            StrategyID = strategyID;
            Description = description;
        }
    }
}
