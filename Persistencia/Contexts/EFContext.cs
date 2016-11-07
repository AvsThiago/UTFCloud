using Modelo;
using Persistencia.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("UTFCloud")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Arquivos> arquivos { get; set; } 
    }
}
