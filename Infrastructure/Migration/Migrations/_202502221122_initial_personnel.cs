using FluentMigrator;

namespace Migration.Migrations;
[Migration(202502221122)]

public class _202502221122_initial_personnel:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Personnels")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Email").AsString().Nullable()
            .WithColumn("NationalCode").AsString(10).NotNullable()
            .WithColumn("PhoneNumber").AsString(11).NotNullable()
            .WithColumn("CreatAt").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Personnels");
    }
}