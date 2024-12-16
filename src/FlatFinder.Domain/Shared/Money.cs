namespace FlatFinder.Domain.Shared
{
    public record Money(decimal Amount, Currency Currency)
	{
		//existe la posibilidad de que el dinero sea 0

		public static Money Zero()
		{
			return new Money(0,Currency.None);
		}

		public static Money Zero(Currency currency)
		{
			return new Money(0, currency);
		}

		public static Money operator +(Money first, Money second)
		{
			if (first.Currency != second.Currency)
			{
				throw new InvalidOperationException("The currencies need to be the sabe");
			}
			return new Money(first.Amount + second.Amount, first.Currency);
		}

		public bool IsZero() => this == Zero(Currency);
	}
}

