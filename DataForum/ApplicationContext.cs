using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataForum
{
   public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WS-LV-CP2922\\SQLEXPRESS;Initial Catalog=forumDatabase; Integrated Security=True");
        }
    }
}
