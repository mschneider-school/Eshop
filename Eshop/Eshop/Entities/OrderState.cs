namespace Eshop.DatabaseEntites
{
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


        public OrderState(int id, string description)
        {
            ID = id;
            Description = description;
        }
    }
}
