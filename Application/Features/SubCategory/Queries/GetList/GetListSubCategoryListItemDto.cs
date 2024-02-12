using System;
namespace Application.Features.SubCategory.Queries.GetList;

public class GetListSubCategoryListItemDto
    {
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string SubCategoryName { get; set; }
    public string SubCategoryDescription { get; set; }
    public string SubCategoryStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}

