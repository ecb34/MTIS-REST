namespace API_MTIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpleado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity:true),
                        NIF = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Poblacion = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        IBAN = c.String(nullable: false),
                        NSS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleadoes");
        }
    }
}
