namespace CoreBase.Dto.IQueryable.OrderBy;

public class Sorting(String field, Boolean ascending = true)
{
    public String Field { get; set; } = field;
    public Boolean Ascending { get; set; } = ascending;
}
