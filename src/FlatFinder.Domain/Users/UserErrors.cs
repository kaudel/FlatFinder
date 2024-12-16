using System;
using FlatFinder.Domain.Abstractions;

namespace FlatFinder.Domain.Users
{
	public class UserErrors
	{
		public static Error NotFound = new Error("User.Found", "The user was not found");
		public static Error InvalidCredentials =
			new Error("User.InvalidCredentials", "The user credentials were not valid");
	}
}

