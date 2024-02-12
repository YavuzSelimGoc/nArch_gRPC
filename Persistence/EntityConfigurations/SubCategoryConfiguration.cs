using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("SubCategories").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(b => b.SubCategoryName).HasColumnName("SubCategoryName").IsRequired();
        builder.Property(b => b.SubCategoryDescription).HasColumnName("SubCategoryDescription").IsRequired();
        builder.Property(b => b.SubCategoryStatus).HasColumnName("SubCategoryStatus").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.SubCategoryName, name: "UK_Sub_Categories_Name").IsUnique();

        builder.HasOne(b => b.Category);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
