using FlatFinder.Domain.Abstractions;

namespace FlatFinder.Domain.Reservations.Events
{
    public sealed record ReservationConfirmedDomainEvent(Guid ReservationID): IDomainEvent;

}

