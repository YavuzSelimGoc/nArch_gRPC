using System;
namespace Application.Features.Category.Commands.Create;

public class CreatedCategoryResponse
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public bool CategoryStatus { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

