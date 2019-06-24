namespace Eshop
{
    class Cathegory
    {
        public const string TableName = "Cathegory";
        public const string IDColumn = "CathegoryID";
        public const string DescriptionColumn = "Description";
        
        public int ID { get; private set; }
        public string Description { get; private set; }

        public Cathegory(int id, string description)
        {
            ID = id;
            Description = description;
        }
    }
}
