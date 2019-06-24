namespace Eshop.DatabaseEntites
{
    class Strategy
    {
        public const string TableName = "Strategy";
        public const string StrategyIDCOlumn = "StrategyID";
        public const string DescriptionColumn = "Description";

        public int StrategyID { get; }
        public string Description { get; }

        public Strategy(int strategyID, string description)
        {
            StrategyID = strategyID;
            Description = description;
        }
    }
}
