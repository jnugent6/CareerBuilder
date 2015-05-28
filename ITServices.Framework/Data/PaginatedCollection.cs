using System.Web;

namespace ITServices.Framework.Data
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class PaginatedCollection<T> : Paginate
    {
        [DataMember]
        public List<T> Collection { get; set; }

        public void PopulatePaginationFields(Uri request)
        {
            if (PerPage > 0)
            {
                PaginationLimit = PerPage;
                PaginationOffset = (Page - 1) * PerPage;
            }

            SetNextURL(request);

            SetPrevURL(request);
        }

        private void SetPrevURL(Uri request)
        {
            if (Page > 1)
            {
                Previous = BuildURLToPage(request, Page - 1, PerPage);
            }
        }

        private void SetNextURL(Uri request)
        {
            if (PaginationOffset + PerPage < TotalRecords)
            {
                Next = BuildURLToPage(request, Page + 1, PerPage);
            }
        }

        private string BuildURLToPage(Uri request, int newPage, int newPerPage)
        {
            var qParams = HttpUtility.ParseQueryString(request.Query);
            qParams.Set("page", newPage.ToString());
            qParams.Set("perpage", newPerPage.ToString());
            return String.Format("{0}?{1}", request.AbsolutePath, qParams.ToString());
        }
    }
}