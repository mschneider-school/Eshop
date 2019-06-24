namespace Eshop.DatabaseEntites
{
    /// <summary>
    /// Trida reprezentuje zaznam tabulky specialnich nabidek (produktu)
    /// </summary>
    public class SpecialOffer
    {
        public const string TableName = "SpecialOffer";
        public const string ProductIDColumn = "ProductID";
        public const string FixedDiscountColumn = "FixedDiscount";

        public int ProductID { get; }
        public int FixedDiscount { get; }

        /// <summary>
        /// Konstruktor specialni nabidky
        /// </summary>
        /// <param name="productID">produktove identifikacni cislo</param>
        /// <param name="fixedDiscount">aplikovana pevna sleva produktu</param>
        public SpecialOffer(int productID, int fixedDiscount)
        {
            ProductID = productID;
            FixedDiscount = fixedDiscount;
        }
    }
}
