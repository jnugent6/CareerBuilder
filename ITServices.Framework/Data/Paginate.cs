namespace ITServices.Framework.Data
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public abstract class Paginate
    {
        [DataMember]
        public int Page { get; set; }

        [DataMember]
        public int PerPage { get; set; }

        [DataMember]
        public string Next { get; set; }

        [DataMember]
        public string Previous { get; set; }

        [DataMember]
        public int TotalRecords { get; set; }

        [DataMember]
        public int TopCount { get; set; }

        [DataMember]
        public int PaginationOffset { get; set; }

        [DataMember]
        public int PaginationLimit { get; set; }

        public void SetPaging(Paginate paging)
        {
            Page = paging.Page;
            PerPage = paging.PerPage;
            PaginationLimit = paging.PaginationLimit;
            PaginationOffset = paging.PaginationOffset;
            Next = paging.Next;
            Previous = paging.Previous;
            TotalRecords = paging.TotalRecords;
            TopCount = paging.TopCount;
        }
    }
}