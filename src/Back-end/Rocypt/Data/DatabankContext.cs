using Microsoft.EntityFrameworkCore;
using Rocypt.Data.Map;
using Rocypt.Models;

namespace Rocypt.Data
{
	public class DatabankContext : DbContext
	{
		public DatabankContext(DbContextOptions<DatabankContext> options) : base (options)
		{ 


		}

		public DbSet<UsuarioModel> Usuarios { get; set; }
		public DbSet<GrupoModel> Grupo { get; set; }
		public DbSet<PasswordModel> Password { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new PasswordMap());

            base.OnModelCreating(modelBuilder);


		}


	}
}
