namespace CoreBase.Dto.IQueryable.Filtering;

public class FilterGroupDto(
   IEnumerable<FilterDto> filters,
   IEnumerable<FilterGroupDto>? childGroups = null,
   String intergroupLogic = "and",
   String interfilterOperator = "and"
   )
{
    public IEnumerable<FilterDto> Filters { get; set; } = filters ?? [];
    public IEnumerable<FilterGroupDto> ChildGroups { get; set; } = childGroups ?? [];
    public String IntergroupLogic { get; set; } = intergroupLogic;
    public String InterfilterOperator { get; set; } = interfilterOperator;
}
