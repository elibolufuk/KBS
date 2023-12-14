using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;

public class ApplicationResultTypeConfiguration : BaseEntityConfiguration<ApplicationResultType, int>
{
    public override void Configure(EntityTypeBuilder<ApplicationResultType> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(ApplicationResultType));
        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(100)
            .HasColumnOrder(ColumnOrder);
    }
}