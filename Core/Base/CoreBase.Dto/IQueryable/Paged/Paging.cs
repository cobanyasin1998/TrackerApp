namespace CoreBase.Dto.IQueryable.Paged;

public class Paging(Int64 page = 1, Int64 size = 10) 
{
    public Int64 Page { get; set; } = page > 0 ? page : 1;
    public Int64 Size { get; set; } = size > 0 ? size : 10;
}
