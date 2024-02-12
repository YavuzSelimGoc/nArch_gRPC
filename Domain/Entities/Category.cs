using System;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category:Entity<Guid>
{
	public string CategoryName { get; set; }
	public string CategoryDescription { get; set; }
	public bool CategoryStatus { get; set; }
	public virtual ICollection<SubCategory> SubCategories { get; set; }
}

