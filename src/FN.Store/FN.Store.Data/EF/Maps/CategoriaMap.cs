using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.Store.Data.EF.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Table
            builder.ToTable(nameof(Categoria));

            //PK
            builder.HasKey(pk => pk.Id);

            //Colunas
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnType("varchar(300)");

            builder.Property(p => p.DataCriacao);
            builder.Property(p => p.DataAlteracao);


        }
    }
}
