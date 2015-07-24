using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class TodoList: DbContext 
    {

        public TodoList()
            : base("name=DbConnectionString")
        {
        } 

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                      
            modelBuilder.Entity<User>().HasKey(p => p.UserId);
            modelBuilder.Entity<User>().Property(c => c.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            modelBuilder.Entity<Task>().HasKey(b => b.TodoId);
            modelBuilder.Entity<Task>().Property(b => b.TodoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Task>().HasRequired(p => p.User)
                .WithMany(b => b.Tasks).HasForeignKey(b => b.UserId); 


            base.OnModelCreating(modelBuilder);
        }

    }
}