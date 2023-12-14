using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;

public class CreditApplicationConfiguration : BaseEntityConfiguration<CreditApplication, Guid>
{
    public override void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(CreditApplication));
        builder.Property(c => c.Amount)
            .IsRequired()
            .HasColumnType("DECIMAL(8,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.LoanTerm)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.InterestRate)
            .IsRequired()
            .HasColumnType("DECIMAL(2,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.ApplicationDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.ApplicationResult)
            .IsRequired()
            .HasDefaultValue(ApplicationResult.RequestReceived)
            .HasColumnOrder(ColumnOrder);

    }
}
