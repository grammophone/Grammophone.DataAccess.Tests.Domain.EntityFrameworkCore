using Grammophone.DataAccess.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grammophone.DataAccess.Tests.Domain.EntityFrameworkCore
{
	/// <summary>
	/// Entity Framework Core test domain container.
	/// </summary>
	public class EFCoreTestDomainContainer : EFCoreDomainContainer
	{
		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="options">The context options.</param>
		public EFCoreTestDomainContainer(DbContextOptions options)
			: base(options)
		{
		}

		#endregion

		#region Public properties

		/// <summary>Parents.</summary>
		public DbSet<Parent> Parents { get; set; }

		/// <summary>Children.</summary>
		public DbSet<Child> Children { get; set; }

		/// <summary>Dependents.</summary>
		public DbSet<Dependent> Dependents { get; set; }

		/// <summary>Event records.</summary>
		public DbSet<EventRecord> Events { get; set; }

		#endregion

		#region Protected methods

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Parent>().HasKey(p => p.ID);
			modelBuilder.Entity<Parent>().Property(p => p.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Parent>().HasIndex(p => p.Name).IsUnique();

			modelBuilder.Entity<Child>().HasKey(c => c.ID);
			modelBuilder.Entity<Child>().Property(c => c.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Child>()
				.HasOne(c => c.Parent)
				.WithMany(p => p.Children)
				.HasForeignKey(c => c.ParentID);

			modelBuilder.Entity<Dependent>().HasKey(d => d.ID);
			modelBuilder.Entity<Dependent>().Property(d => d.Name).IsRequired().HasMaxLength(200);

			modelBuilder.Entity<EventRecord>().HasKey(e => e.ID);
			modelBuilder.Entity<EventRecord>().Property(e => e.Name).IsRequired().HasMaxLength(200);
		}

		#endregion
	}
}
