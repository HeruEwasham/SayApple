using System.Threading.Tasks;

namespace SayApple
{
    public class Speech
    {
        public string Name { get; }

        public string CountryCode { get; }

        public string Quote { get; }

        internal Speech(string name, string countryCode, string quote)
        {
            Name = name;
            CountryCode = countryCode;
            Quote = quote;
        }

        public async Task SayQuoteAsync()
        {
            await Say.SayAsync(Quote, Name);
        }
    }
}