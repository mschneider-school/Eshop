namespace Eshop.DatabaseEntites
{
    public class SpecialOffer
    {
        public const string TableName = "SpecialOffer";
        public const string ProductIDColumn = "ProductID";
        public const string FixedDiscountColumn = "FixedDiscount";

        public int ProductID { get; }
        public int FixedDiscount { get; }

        public SpecialOffer(int productID, int fixedDiscount)
        {
            ProductID = productID;
            FixedDiscount = fixedDiscount;
        }
    }
}
