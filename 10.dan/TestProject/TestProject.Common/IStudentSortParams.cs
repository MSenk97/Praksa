namespace TestProject.Common
{
    public interface IStudentSortParams
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }

        bool ValidInput();
        
    }
}