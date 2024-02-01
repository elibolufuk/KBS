using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;
public class CreditApplicationEntityConfiguration : BaseEntityConfiguration<CreditApplication, Guid>
{
    public override void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(CreditApplication), EntitySchema.Credit.ToString());

        builder.Property(c => c.CustomerId)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.ApplicationResultType)
            .IsRequired()
            .HasDefaultValue(ApplicationResultType.RequestReceived)
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.Amount)
            .IsRequired()
            .HasColumnType("DECIMAL(10,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.LoanTerm)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.InterestRate)
            .IsRequired()
            .HasColumnType("DECIMAL(4,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.ApplicationDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasColumnOrder(ColumnOrder);

        builder.HasOne(o => o.Customer)
            .WithMany(m => m.CreditApplications)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}