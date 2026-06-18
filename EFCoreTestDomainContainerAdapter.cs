using Grammophone.DataAccess.EntityFrameworkCore;

namespace Grammophone.DataAccess.Tests.Domain.EntityFrameworkCore
{
	/// <summary>
	/// Entity Framework Core test domain container adapter.
	/// </summary>
	public class EFCoreTestDomainContainerAdapter : EFCoreDomainContainerAdapter<EFCoreTestDomainContainer>, ITestDomainContainer
	{
		#region Private fields

		private IEntitySet<Parent> parents;
		private IEntitySet<Child> children;
		private IEntitySet<Dependent> dependents;
		private IEntitySet<EventRecord> events;

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

		#region ITestDomainContainer implementation

		/// <inheritdoc/>
		public IEntitySet<Parent> Parents => parents ??= new EFCoreSet<Parent>(this.InnerDomainContainer.Parents, this);

		/// <inheritdoc/>
		public IEntitySet<Child> Children => children ??= new EFCoreSet<Child>(this.InnerDomainContainer.Children, this);

		/// <inheritdoc/>
		public IEntitySet<Dependent> Dependents => dependents ??= new EFCoreSet<Dependent>(this.InnerDomainContainer.Dependents, this);

		/// <inheritdoc/>
		public IEntitySet<EventRecord> Events => events ??= new EFCoreSet<EventRecord>(this.InnerDomainContainer.Events, this);

		#endregion
	}
}
