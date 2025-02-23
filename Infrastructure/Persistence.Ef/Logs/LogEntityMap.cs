namespace Persistence.Ef.Logs;

public class LogEntityMap:IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Date).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.Message).IsRequired();
        builder.Property(x => x.Exception).IsRequired(false);
    }
}