using System;
using FlatFinder.Domain.Abstractions;

namespace FlatFinder.Domain.Reviews
{
	public static class ReviewErrors
	{
		public static readonly Error NotElegible =
			new("Review.NotElegible", "You cannot make a review because you did't reserved a flat");
	}
}

