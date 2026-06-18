using Grammophone.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grammophone.DataAccess.Tests.Domain.EntityFrameworkCore
{
	/// <summary>
	/// Entity Framework Core test domain container.
	/// </summary>
	public class EFCoreMusicDomainContainer : EFCoreDomainContainer
	{
		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="options">The context options.</param>
		public EFCoreMusicDomainContainer(DbContextOptions options)
			: base(options)
		{
		}

		#endregion

		#region Public properties

		/// <summary>Artists.</summary>
		public DbSet<Artist> Artists { get; set; }

		/// <summary>Albums.</summary>
		public DbSet<Album> Albums { get; set; }

		/// <summary>Tracks.</summary>
		public DbSet<Track> Tracks { get; set; }

		/// <summary>Genres.</summary>
		public DbSet<Genre> Genres { get; set; }

		#endregion

		#region Protected methods

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Artist>().HasKey(a => a.ID);
			modelBuilder.Entity<Artist>().Property(a => a.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Artist>().HasIndex(a => a.Name).IsUnique();

			modelBuilder.Entity<Album>().HasKey(a => a.ID);
			modelBuilder.Entity<Album>().Property(a => a.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Album>().HasIndex(a => a.Name).IsUnique();
			modelBuilder.Entity<Album>()
				.HasOne(a => a.Artist)
				.WithMany(a => a.Albums)
				.HasForeignKey(a => a.ArtistID);
			modelBuilder.Entity<Album>()
				.HasOne(a => a.Genre)
				.WithMany(g => g.Albums)
				.HasForeignKey(a => a.GenreID);

			modelBuilder.Entity<Track>().HasKey(t => t.ID);
			modelBuilder.Entity<Track>().Property(t => t.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Track>()
				.HasOne(t => t.Album)
				.WithMany(a => a.Tracks)
				.HasForeignKey(t => t.AlbumID);
			modelBuilder.Entity<Track>()
				.HasOne(t => t.Genre)
				.WithMany(g => g.Tracks)
				.HasForeignKey(t => t.GenreID);

			modelBuilder.Entity<Genre>().HasKey(g => g.ID);
			modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Genre>().HasIndex(g => g.Name).IsUnique();
		}

		#endregion
	}
}
