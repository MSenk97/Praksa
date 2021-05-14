using System;

namespace TestProject.Common
{
    public class StudentSortParams
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public bool IsValid()
        {
            if (IsNull())
            {
                return true;
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

            switch (SortBy)
            {
                case "Ime":
                    break;
                case "FakultetID":
                    break;
                default:
                    return false;
            }

            return true;
        }

        public bool IsNull()
        {
            return SortBy == null && SortOrder == null;
        }
    }
}