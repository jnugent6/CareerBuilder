namespace ITServices.Framework.Extensions
{
    using System.Linq;

    using ITServices.Framework.Data;

    public static class PaginateExtensions
    {
        public const int _PAGE_DEFAULT = 1;
        public const int _PER_PAGE_DEFAULT = 25;

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber = _PAGE_DEFAULT, int itemsPerPage = _PER_PAGE_DEFAULT)
        {
            return query.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Paginate pagination)
        {
            return query.Paginate(PageOrDefault(pagination), PerPageOrDefault(pagination));
        }

        private static int PerPageOrDefault(Paginate pagination)
        {
            if (pagination.PerPage == 0)
            { pagination.PerPage = _PER_PAGE_DEFAULT; }
            return pagination.PerPage;
        }

        private static int PageOrDefault(Paginate pagination)
        {
            if (pagination.Page == 0)
            {
                pagination.Page = _PAGE_DEFAULT;
            }

            return pagination.Page;
        }
    }
}