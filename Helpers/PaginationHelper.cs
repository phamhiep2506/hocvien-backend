namespace Helpers;

public static class PaginationHelper<T>
{
    public static List<T> Pagination(List<T> source, int page, int pageSize)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < 1 ? 1 : pageSize;

        return source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
}
