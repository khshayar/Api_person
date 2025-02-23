using Entities.Personnels;

namespace Persistence.Ef.Personnels;

public class PersonnelEntityMap:IEntityTypeConfiguration<Personnel>
{
    public void Configure(EntityTypeBuilder<Personnel> builder)
    {
        builder.ToTable("Personnels");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x=>x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Email).IsRequired(false);
        builder.Property(x => x.NationalCode).HasMaxLength(10).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(11).IsRequired();
        builder.Property(x=>x.CreatAt).IsRequired();
    }
}