using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyModel.DataBaseContext
{
    public class StudyBudyDatabaseDbContex : DbContext
    {
        public StudyBudyDatabaseDbContex() : base("StudyBuddyContext")
        {

        }

        public DbSet<User> Users { get; set; }

        //TO DO 
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
