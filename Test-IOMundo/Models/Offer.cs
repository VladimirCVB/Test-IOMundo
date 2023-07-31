namespace Test_IOMundo.Models
{
    public class Offer
    {
        public string Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public int StayDurationNights { get; set; }
        public string PersonCombination { get; set; }
        public string ServiceCode { get; set; }
        public int Price { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public int StrikePrice { get; set; }
        public int StrikePricePerAdult { get; set; }

        public int StrikePricePerChild { get; set; }
        public bool ShowStrikePrice { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
