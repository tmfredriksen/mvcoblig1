namespace Blogg.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseModel : DbContext
    {
        // Your context has been configured to use a 'DatabaseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Blogg.Models.DatabaseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseModel' 
        // connection string in the application configuration file.
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Blog> Blogs { get; set; }
         public virtual DbSet<Post> Posts { get; set; }
         public virtual DbSet<Comment> Comments { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}