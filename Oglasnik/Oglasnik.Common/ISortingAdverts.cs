namespace Oglasnik.Common
{
    public interface ISortingAdverts
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }

        bool Sort();
    }
}