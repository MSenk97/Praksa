using System;

namespace TestProject.Common
{
    public class StudentSortParams :  IStudentSortParams
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public bool ValidInput()
        {
            if (SortBy == null && SortOrder == null)
            {
                return true;
            }

            switch (SortBy)
            {
                case "StudentID":
                    break;
                case "Ime":
                    break;
                case "FakultetID":
                    break;
                default:
                    return false;
            }

            switch (SortOrder)
            {
                case "asc":
                    break;
                case "desc":
                    break;
                default:
                    return false;
            }

            return true;
        }
    
    }
}