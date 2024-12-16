using FlatFinder.Domain.Abstractions;

namespace FlatFinder.Domain.Reservations.Events
{
    public sealed record ReservationCancelDomainEvent(Guid ReservationId):IDomainEvent;
}

