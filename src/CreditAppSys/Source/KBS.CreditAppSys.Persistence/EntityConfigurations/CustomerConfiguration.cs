using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;
public class CustomerConfiguration : BaseEntityConfiguration<Customer, Guid>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(Customer));
        builder.Property(p => p.IdentityNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(11)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.Surname)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100)
            .HasColumnOrder(ColumnOrder);
    }
}