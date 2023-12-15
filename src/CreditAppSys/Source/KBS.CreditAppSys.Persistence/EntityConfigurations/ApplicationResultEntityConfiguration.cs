using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;

public class ApplicationResultEntityConfiguration : BaseTypeEntityConfiguration<ApplicationResult, byte>
{
    public override void Configure(EntityTypeBuilder<ApplicationResult> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(ApplicationResult), EntitySchema.Credit.ToString());
        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50)
            .HasColumnOrder(ColumnOrder);

        
    }
}