namespace TestProject.CommonInterface
{
    public interface IStudentSortParams
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }
        bool ValidInput();
    }
}
