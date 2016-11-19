using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using UTFCloud.Models;

namespace ProjetoAspMVC.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDb") { }

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }

        public System.Data.Entity.DbSet<UTFCloud.Models.UsuarioViewModel> UsuarioViewModels { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
    {
    }
}
