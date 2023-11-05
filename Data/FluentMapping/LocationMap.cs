using IbgeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApi.Data.FluentMapping;

public class LocationMap : IEntityTypeConfiguration<LocationModel>
{
    public void Configure(EntityTypeBuilder<LocationModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ComplexProperty(t => t.State)
            .Property(t => t.StateName)
            .HasColumnType(SqlDataTypes.Nvarchar)
            .HasColumnName("state");

        builder.ComplexProperty(t => t.City)
            .Property(t => t.CityName)
            .HasColumnType(SqlDataTypes.Nvarchar)
            .HasColumnName("city");

        builder.Property(t => t.CreatedAt)
            .HasColumnType(SqlDataTypes.Datetime2)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.Property(t => t.UpdatedAt)
            .HasColumnType(SqlDataTypes.Datetime2)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}