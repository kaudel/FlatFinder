using FlatFinder.Domain.Flats;

namespace FlatFinder.Domain.Reservations
{
    public interface IReservationRepository
	{
		Task<Reservation?> getByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<bool> IsOverLappingAsync(Flat flat, DateRange duration, CancellationToken cancellationToken = default);
		void Add(Reservation reservation);
	}
}

