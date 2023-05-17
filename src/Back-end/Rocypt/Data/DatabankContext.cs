using Microsoft.EntityFrameworkCore;
using Rocypt.Models;

namespace Rocypt.Data
{
	public class DatabankContext : DbContext
	{
		public DatabankContext(DbContextOptions<DatabankContext> options) : base (options)
		{ 


		}

		public DbSet<UsuarioModel> Usuarios { get; set; }


	}
}
