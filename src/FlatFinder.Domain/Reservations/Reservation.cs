using FlatFinder.Domain.Abstractions;
using FlatFinder.Domain.Flats;
using FlatFinder.Domain.Reservations.Events;

namespace FlatFinder.Domain.Reservations
{
    public sealed class Reservation:Entity
	{
		public Reservation(
            Guid id,
            Guid flatId,
            Guid userId,
            DateRange duration,
            PricingDetails pricingDetails,
            ReservationStatus status,
            DateTime createdOnUtc):base(id)
		{
            FlatId = flatId;
            Status = status;
            UserId = userId;
            Duration = duration;
            PricingDetails = pricingDetails;
            Status = status;
            CreatedOnUtc = createdOnUtc;             
		}

		public Guid FlatId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public PricingDetails PricingDetails { get; private set; }
        public ReservationStatus Status { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancellededOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }

        public static Reservation Reserve(
            Flat flat,
            Guid userId,
            DateRange duration,
            DateTime utcNow,
            PricingService pricingService)
        {
            var pricingDetails = pricingService.CalculatePrice(flat, duration);
            var reservation = new Reservation(Guid.NewGuid(), flat.Id, userId, duration, pricingDetails, ReservationStatus.Reserved, utcNow);
            reservation.RaiseDomainEvents(new ReservationsReservedDomainEvent(reservation.Id));
            flat.LastBookedOnUtc = utcNow;
            return reservation;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != ReservationStatus.Reserved)
            {
                return Result.Failure(ReservationErrors.NotReserved);
            }

            Status = ReservationStatus.Confirmed;
            ConfirmedOnUtc = utcNow;

            RaiseDomainEvents(new ReservationConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != ReservationStatus.Reserved)
            {
                return Result.Failure(ReservationErrors.NotReserved);
            }

            Status = ReservationStatus.Rejected;
            RejectedOnUtc = utcNow;

            RaiseDomainEvents(new ReservationConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != ReservationStatus.Reserved)
            {
                return Result.Failure(ReservationErrors.NotReserved);
            }

            Status = ReservationStatus.Completed;
            CompletedOnUtc = utcNow;

            RaiseDomainEvents(new ReservationConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != ReservationStatus.Reserved)
            {
                return Result.Failure(ReservationErrors.NotReserved);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start)
                return Result.Failure(ReservationErrors.AlreadyStarted);

            Status = ReservationStatus.Cancelled;
            CancellededOnUtc = utcNow;

            RaiseDomainEvents(new ReservationConfirmedDomainEvent(Id));
            return Result.Success();
        }
    }
}

