namespace Test_IOMundo.Models
{
    public class Price
    {
        public Price() { }
        public Price(int adultDayPrice, int childDayPrice)
        {
            OneDayPricePerAdult = adultDayPrice;
            OneDayPricePerChild = childDayPrice;
        }
        public int TotalPrice { get; set; } = 0;
        public int PricePerAdult { get; set; } = 0;
        public int PricePerChild { get; set; } = 0;
        public int OneDayPricePerAdult { get; } = 100;
        public int OneDayPricePerChild { get; } = 50;

        public int calculateTotalPrice()
        {
            return PricePerAdult + PricePerChild;
        }
    }
}
