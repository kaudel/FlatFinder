using System;
namespace FlatFinder.Domain.Reservations
{
	public record DateRange
	{
		private DateRange() { }

		public DateOnly Start { get; init; }
		public DateOnly End { get; init; }

		public int LenghInDays => End.DayNumber - Start.DayNumber;

		public static DateRange Create(DateOnly start, DateOnly end)
		{
			if (start > end)
				throw new ApplicationException("End date cannot be later than start");

            return new DateRange
			{
				Start = start,
				End = end
			};
		}
	}
}

