using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Data_Access.Data
{
    public class TodoList:DbContext
    {
        public TodoList()
            : base("name=DbConnectionString")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Task>().HasKey(t => t.TodoId);
            modelBuilder.Entity<Task>().Property(t => t.TodoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<Task>().HasRequired(t => t.User).WithMany(u => u.Tasks).HasForeignKey(t => t.User);
            
            
           


            base.OnModelCreating(modelBuilder);
        }
    }
}