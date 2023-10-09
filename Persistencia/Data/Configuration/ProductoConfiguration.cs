
using System.Collections.Immutable;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");
        builder.Property(e => e.NombreProducto)
        .HasColumnName("nombre_producto")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.CantidadMax)
        .HasColumnName("cantidad_max")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(e => e.CantidadMin)
        .HasColumnName("cantidad_min")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(e => e.Codigo)
        .HasColumnName("codigo")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Precio)
        .HasColumnName("precio")
        .HasColumnType("double")
        .IsRequired();

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.HasIndex(e => e.Codigo).IsUnique();

        builder.HasOne(e => e.Marca)
        .WithMany(e => e.Productos)
        .HasForeignKey(e => e.IdMarcaFk);


    }
}
