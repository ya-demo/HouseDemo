
namespace HouseDemo.Common.PageExtention;

public static class PageExtention
{
    public static PageResult<T> Pages<T>(this List<T> list, int? rows = null, int? page = null)
    {
        if (!page.HasValue && !rows.HasValue)
        {
            return new PageResult<T>
            {
                Total = list.Count,
                Data = list
            };
        }
        else
        {
            if (!page.HasValue)
                page = 1;
            if (!rows.HasValue)
                rows = 20;
            return new PageResult<T>
            {
                Page = page,
                Rows = rows,
                Total = list.Count,
                Data = list.Skip((page.Value - 1) * rows.Value).Take(rows.Value).ToList()
            };
        }
    }
}




