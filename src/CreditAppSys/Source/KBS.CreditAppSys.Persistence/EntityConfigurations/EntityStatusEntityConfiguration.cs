using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteArch.Base.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KBS.CreditAppSys.Persistence.EntityConfigurations;
public class EntityStatusEntityConfiguration : BaseTypeEntityConfiguration<EntityStatus, byte>
{
    public override void Configure(EntityTypeBuilder<EntityStatus> builder)
    {
        base.ConfigureBase(builder);
        builder.ToTable(nameof(EntityStatus), EntitySchema.Credit.ToString());
        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50)
            .HasColumnOrder(ColumnOrder);
    }
}