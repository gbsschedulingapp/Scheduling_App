namespace Scheduling_App.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyModel : DbContext
    {
        // Your context has been configured to use a 'MyModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Scheduling_App.Models.MyModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyModel' 
        // connection string in the application configuration file.
        public MyModel()
            : base("name=MyModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Appointment> appointments { get; set; }
        public virtual DbSet<Services> servicess { get; set; }
        public virtual DbSet<TimeSlots> timeSlotss { get; set; }
        public virtual DbSet<UserServices> userServicess { get; set; }
        public virtual DbSet<UserCustomer> UserCustomers { get; set; }

        public System.Data.Entity.DbSet<Scheduling_App.ViewModels.SearchVM> SearchVMs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}