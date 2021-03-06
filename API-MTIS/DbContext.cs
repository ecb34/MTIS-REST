﻿namespace API_MTIS
{
    using API_MTIS.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbContext : System.Data.Entity.DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'Model1' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'API_MTIS.Model1' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Model1'  en el archivo de configuración de la aplicación.
        public DbContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Empleado.Models.Empleado> Empleado { get; set; }
        
        public virtual DbSet<Permiso> Permiso { get; set; }

        public virtual DbSet<RestKey> RestKey { get; set; }
        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}