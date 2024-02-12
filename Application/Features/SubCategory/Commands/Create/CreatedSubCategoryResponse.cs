using System;
namespace Application.Features.SubCategory.Commands.Create;

public class CreatedSubCategoryResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string SubCategoryName { get; set; }
    public string SubCategoryDescription { get; set; }
    public bool SubCategoryStatus { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

