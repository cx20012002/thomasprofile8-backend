using Microsoft.EntityFrameworkCore;

namespace API.RequestHelpers
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            MetaData = new MetaData { TotalCount = count, PageSize = pageSize, CurrentPage = pageNumber, TotalPages = (int)Math.Ceiling(count / (double)pageSize) };
            AddRange(items);
        }

        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var count = await query.CountAsync(cancellationToken);
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return new PagedList<T>(items, count, pageNumber, pageSize, cancellationToken);
        }
    }
}