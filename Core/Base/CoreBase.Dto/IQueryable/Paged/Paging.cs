namespace CoreBase.Dto.IQueryable.Paged;

public class Paging(Int32 page = 1, Int32 size = 10) 
{
    public Int32 Page { get; set; } = page > 0 ? page : 1;
    public Int32 Size { get; set; } = size > 0 ? size : 10;
}
