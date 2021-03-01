using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSProjects.Models;

namespace OSProjects.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<CharacterSkill>().HasKey(x => new { x.CharacterId, x.SkillId });
            //modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("player");
        }
    }
}
