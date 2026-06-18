using Grammophone.DataAccess.EntityFrameworkCore;

namespace Grammophone.DataAccess.Tests.Domain.EntityFrameworkCore
{
	/// <summary>
	/// Entity Framework Core test domain container adapter.
	/// </summary>
	public class EFCoreTestDomainContainerAdapter : EFCoreDomainContainerAdapter<EFCoreTestDomainContainer>, IMusicDomainContainer
	{
		#region Private fields

		private IEntitySet<Artist> artists;
		private IEntitySet<Album> albums;
		private IEntitySet<Track> tracks;
		private IEntitySet<Genre> genres;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="innerContainer">The adapted domain container.</param>
		public EFCoreTestDomainContainerAdapter(EFCoreTestDomainContainer innerContainer)
			: base(innerContainer)
		{
		}

		#endregion

		#region IMusicDomainContainer implementation

		/// <inheritdoc/>
		public IEntitySet<Artist> Artists => artists ??= new EFCoreSet<Artist>(this.InnerDomainContainer.Artists, this);

		/// <inheritdoc/>
		public IEntitySet<Album> Albums => albums ??= new EFCoreSet<Album>(this.InnerDomainContainer.Albums, this);

		/// <inheritdoc/>
		public IEntitySet<Track> Tracks => tracks ??= new EFCoreSet<Track>(this.InnerDomainContainer.Tracks, this);

		/// <inheritdoc/>
		public IEntitySet<Genre> Genres => genres ??= new EFCoreSet<Genre>(this.InnerDomainContainer.Genres, this);

		#endregion
	}
}
