using System;
using FlatFinder.Domain.Flats;
using FlatFinder.Domain.Shared;

namespace FlatFinder.Domain.Reservations
{
    public record PricingDetails(
        Money PriceForPeriod,
        Money CleaningFee,
        Money AmenitiesUpCharge,
        Money TotalPrice);
}

