namespace CoreBase.Dto.IQueryable.Paged;

public class Paging(int page = 1, int size = 10) 
{
    public int Page { get; set; } = page > 0 ? page : 1;
    public int Size { get; set; } = size > 0 ? size : 10;
}
