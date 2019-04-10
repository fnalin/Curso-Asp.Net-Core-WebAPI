using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.Store.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Table
            builder.ToTable(nameof(Produto));

            //PK
            builder.HasKey(pk => pk.Id);

            //Colunas
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Preco)
               .HasColumnType("money");

            builder.Property(p => p.DataCriacao);
            builder.Property(p => p.DataAlteracao);


        }
    }
}
