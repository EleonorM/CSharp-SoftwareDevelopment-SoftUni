namespace _04.Telephony
{
    using System.Linq;
    public class Smartphone : IBrowser, ICaller
    {
        public string Browse(string site)
        {
            if (site.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }
    }
}
