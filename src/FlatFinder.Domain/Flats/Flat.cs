using FlatFinder.Domain.Abstractions;
using FlatFinder.Domain.Shared;

namespace FlatFinder.Domain.Flats
{
    public sealed class Flat:Entity
	{
		public Flat(Guid id) : base(id)
		{ }
		public Guid Id { get; private set; }
		public Name Name { get; private set; }
		public Description Description { get; private set; }
		public Adress Adress { get; private set; }
		public Money Price { get; private set; }
		public Money CleaningFee { get; private set; }
		public List<Amenity> Amenities { get;  set; } = new();
		public DateTime? LastBookedOnUtc { get; internal set; }
	}
}

 