using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;

public class CustomerCriteriaEntityConfiguration : BaseEntityConfiguration<CustomerCriteria, Guid>
{
    public override void Configure(EntityTypeBuilder<CustomerCriteria> builder)
    {
        /*
    public Int16 CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }//Gelir
    public decimal MonthlyDebt { get; set; }//Borç
    public bool AdverseCreditHistory { get; set; }//Olumsuz Kredi Geçmişi
         */
        base.ConfigureBase(builder);
        builder.ToTable(nameof(CustomerCriteria), EntitySchema.Credit.ToString());

        builder.Property(c => c.CustomerId)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.CreditScore)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.MonthlyIncome)
            .IsRequired()
            .HasColumnType("DECIMAL(8,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.MonthlyDebt)
            .IsRequired()
            .HasColumnType("DECIMAL(8,2)")
            .HasColumnOrder(ColumnOrder);

        builder.Property(c => c.AdverseCreditHistory)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.HasOne(o => o.Customer)
            .WithMany(m => m.CustomerCriterias)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}