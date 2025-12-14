using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Common
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
