using System;
namespace FlatFinder.Domain.Flats
{
	public record Adress(string Country,
		string State,
		string ZpCode,
		string City,
		string Street);
}

