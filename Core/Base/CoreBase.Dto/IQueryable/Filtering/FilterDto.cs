namespace CoreBase.Dto.IQueryable.Filtering;
public class FilterDto
{
    public String Member { get; set; } = String.Empty;
    public Object? FilterValue { get; set; } = null;
    public String FilterOperator { get; set; } = String.Empty;
}
