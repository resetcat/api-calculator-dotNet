namespace api_calc_net.Models
{
    public class Countries
    {
        public List<string> countries { get; }

        public Countries(List<string> countries)
        {
            this.countries = countries;
        }
    }
}
