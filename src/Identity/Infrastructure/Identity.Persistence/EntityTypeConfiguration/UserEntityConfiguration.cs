using CoreBase.Identity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.EntityTypeConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        // Tablo adı (opsiyonel)
        builder.ToTable("Users");

        // Primary Key
        builder.HasKey(x => x.Id);

        // OrganizationEntityId
        builder.Property(x => x.OrganizationEntityId)
            .IsRequired();

        // Username (Maksimum 30 karakter, opsiyonel)
        builder.Property(x => x.Username)
            .HasMaxLength(30)
            .IsUnicode(false);

        // Email (Maksimum 256 karakter, opsiyonel)
        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .IsUnicode(false);

        // FirstName
        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsUnicode(false);

        // SecondName
        builder.Property(x => x.SecondName)
            .HasMaxLength(100)
            .IsUnicode(false);

        // LastName
        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsUnicode(false);

        // PhoneNumber
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(15)
            .IsUnicode(false);

        // PasswordSalt (Required)
        builder.Property(x => x.PasswordSalt)
            .IsRequired();

        // PasswordHash (Required)
        builder.Property(x => x.PasswordHash)
            .IsRequired();

        // FailedLoginAttempts
        builder.Property(x => x.FailedLoginAttempts);

        // Bio
        builder.Property(x => x.Bio)
            .HasMaxLength(500);

        // DateOfBirth
        builder.Property(x => x.DateOfBirth);

        // Gender
        builder.Property(x => x.Gender)
            .IsRequired();
    }
}
