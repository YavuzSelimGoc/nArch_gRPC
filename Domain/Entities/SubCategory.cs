using System;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SubCategory:Entity<Guid>
{
	public Guid CategoryId { get; set; }
	public string  SubCategoryName { get; set; }
	public string  SubCategoryDescription { get; set; }
	public bool  SubCategoryStatus { get; set; }
	public virtual Category? Category { get; set; }
}

