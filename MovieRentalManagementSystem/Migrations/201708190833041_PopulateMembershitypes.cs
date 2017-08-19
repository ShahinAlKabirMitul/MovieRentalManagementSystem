namespace MovieRentalManagementSystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershitypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name='Silver Member' where id=1");
            Sql("Update MembershipTypes set Name='Gold Member' where id=2");
            Sql("Update MembershipTypes set Name='Platinum Member' where id=3");
            Sql("Update MembershipTypes set Name='Platinum Plss Member' where id=4");
        }

        public override void Down()
        {
        }
    }
}
