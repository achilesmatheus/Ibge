using IbgeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApi.Data.FluentMapping;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ComplexProperty(t => t.Name)
            .Property(t => t.FirstName)
            .HasColumnType(SqlDataTypes.Nvarchar)
            .HasMaxLength(80);

        builder.ComplexProperty(t => t.Email)
            .Property(t => t.EmailAddress)
            .HasColumnType(SqlDataTypes.Nvarchar)
            .HasMaxLength(80);

        builder.ComplexProperty(t => t.PasswordHash)
            .Property(t => t.Hash)
            .HasColumnType(SqlDataTypes.Nvarchar)
            .HasMaxLength(80);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.CreatedAt)
            .HasColumnType(SqlDataTypes.Datetime2)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.UpdatedAt)
            .HasColumnType(SqlDataTypes.Datetime2)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}