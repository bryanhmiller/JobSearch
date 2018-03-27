namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Interest = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.Int(nullable: false),
                        Culture = c.String(),
                        Applications_Id = c.Int(),
                        Communication_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.Applications_Id)
                .ForeignKey("dbo.Communications", t => t.Communication_Id)
                .Index(t => t.Applications_Id)
                .Index(t => t.Communication_Id);
            
            DropColumn("dbo.Communications", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Communications", "Company", c => c.String());
            DropForeignKey("dbo.Companies", "Communication_Id", "dbo.Communications");
            DropForeignKey("dbo.Companies", "Applications_Id", "dbo.Applications");
            DropIndex("dbo.Companies", new[] { "Communication_Id" });
            DropIndex("dbo.Companies", new[] { "Applications_Id" });
            DropTable("dbo.Companies");
            DropTable("dbo.Applications");
        }
    }
}
