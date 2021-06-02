using HomeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HomeLibrary.DAL
{
    public class BookContext : DbContext
    {
        //The name of the connection string is passed in to the constructor.
        public BookContext() : base("BookContext")
        {
        }
        /*This code creates a DbSet property for each entity set. 
        In Entity Framework terminology, an entity set typically corresponds to a database table, 
        and an entity corresponds to a row in the table.*/
        public DbSet<Book> Books { get; set; }

        /*The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized.*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}