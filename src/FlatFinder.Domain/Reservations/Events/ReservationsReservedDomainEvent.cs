using System;
using FlatFinder.Domain.Abstractions;

namespace FlatFinder.Domain.Reservations.Events
{
	public sealed record ReservationsReservedDomainEvent(Guid ReservationId): IDomainEvent
	{

	}
}

