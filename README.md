# Grammophone.DataAccess.Tests.Domain.EntityFrameworkCore

Entity Framework Core implementation of the shared music test domain.

This project defines `EFCoreMusicDomainContainer` and `EFCoreMusicDomainContainerAdapter`, mapping the portable `IMusicDomainContainer` contract from `Grammophone.DataAccess.Tests.Domain` to EF Core `DbSet` properties and adapted `IEntitySet<T>` properties.

It references [Grammophone.DataAccess](https://github.com/grammophone/Grammophone.DataAccess/tree/adaptQueryOperations) and `Grammophone.DataAccess.EntityFrameworkCore`. The music model opts into EF Core change-tracking proxies so the test entities use virtual mapped properties and notification-capable collections.
