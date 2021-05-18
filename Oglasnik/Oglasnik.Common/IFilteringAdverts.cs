namespace Oglasnik.Common
{
    public interface IFilteringAdverts
    {
        int CategoryID { get; set; }
        string Condition { get; set; }
        int PriceMin { get; set; }
        int PriceMax { get; set; }
        string Title { get; set; }

        string HowToFilter();
    }
}