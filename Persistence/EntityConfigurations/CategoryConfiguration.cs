using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CategoryName).HasColumnName("CategoryName").IsRequired();
        builder.Property(b => b.CategoryDescription).HasColumnName("CategoryDescription").IsRequired();
        builder.Property(b => b.CategoryStatus).HasColumnName("CategoryStatus").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.CategoryName, name: "UK_Categories_Name").IsUnique();

        builder.HasMany(b => b.SubCategories);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
