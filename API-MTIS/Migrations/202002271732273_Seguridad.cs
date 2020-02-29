namespace API_MTIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seguridad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permisoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sala = c.String(nullable: false),
                        NIF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestKeys",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestKeys");
            DropTable("dbo.Permisoes");
        }
    }
}
