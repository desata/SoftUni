using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private decimal marketCapitalization;


        public Stock(string companyName, string director, decimal pricePerShare, int totalNumbersOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumbersOfShares;
            MarketCapitalization = totalNumbersOfShares * pricePerShare;
        }

        public string CompanyName { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }

        //public override string ToString()
        //{
        //    return $"Company: {CompanyName}\rn Director: { Director}\rn Price per share: ${ PricePerShare}\rn Market capitalization: ${ MarketCapitalization}";
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: " + CompanyName)
                .AppendLine($"Director: " + Director)
                .AppendLine($"Price per share: $" + PricePerShare)
                .AppendLine($"Market capitalization: $" + MarketCapitalization);

            return sb.ToString();
        }
    }
}
