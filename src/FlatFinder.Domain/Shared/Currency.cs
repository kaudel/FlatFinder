namespace FlatFinder.Domain.Shared
{
	public record Currency
	{
		// DDD Always valid model

		//It is defined as internal because the value only need to be available
		//inside the domain project, not outside
		internal static readonly Currency None = new Currency("");
		public static readonly Currency Usd = new Currency("USD");
        public static readonly Currency Eur = new Currency("EUR");
        public static readonly Currency Pen = new Currency("PEN");
        public static readonly Currency Mxn = new Currency("MXN");

		//tambien podria funcionar con un List<>
		public static readonly IReadOnlyCollection<Currency> All =
			new[] { Usd, Eur, Pen, Mxn };

        public Currency(string code)
		{
			Code = code;
		}

		public string Code { get; init; }

		public static Currency FromCode(string code)
		{
			return All.FirstOrDefault(x => x.Code == code) ??
				throw new ApplicationException("The currency is not valid");
		}
	}
}

