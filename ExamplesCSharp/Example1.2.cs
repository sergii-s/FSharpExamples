namespace ExamplesCSharp
{

	public class MetricQuery
	{
		public readonly int? CatalogId;
		public readonly int? CampaignId;
		public readonly string UserTypology;
		public readonly string Publisher;
		//.......

		public MetricQuery(int? catalogId, int? campaignId, string userTypology, string publisher)
		{
			CatalogId = catalogId;
			CampaignId = campaignId;
			UserTypology = userTypology;
			Publisher = publisher;
		}
	}

	public class MetricQueryBuilder
	{
		private int? _campaignId;
		private int? _catalogId;
		private string _publisher;
		private string _userTypology;
		//.......

		public MetricQueryBuilder WithCampaignId(int campaignId)
		{
			_campaignId = campaignId;
			return this;
		}

		public MetricQueryBuilder WithCatalogId(int catalogId)
		{
			_catalogId = catalogId;
			return this;
		}

		public MetricQueryBuilder WithPublisher(string publisher)
		{
			_publisher = publisher;
			return this;
		}

		public MetricQueryBuilder WithUserTypology(string userTypology)
		{
			_userTypology = userTypology;
			return this;
		}

		public MetricQuery Create()
		{
			return new MetricQuery(_catalogId, _campaignId, _userTypology, _publisher);
		}
	}

	public class Example2
	{
		public static void Example()
		{
			var builder = new MetricQueryBuilder();
			var metricQuery = builder.WithCampaignId(10).WithCatalogId(20).Create();
		}
	}

}
