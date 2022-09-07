using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class HistoryItem
	{
		public HistoryItem()
		{
			Entries = new List<MinimizedSale>();
			StackSizeHistogram = new Dictionary<int, int>();
			StackSizeHistogramNq = new Dictionary<int, int>();
			StackSizeHistogramHq = new Dictionary<int, int>();
		}

		[JsonProperty("itemID")]
		public int Id { get; set; }

		[JsonProperty("worldID")]
		public int? WorldId { get; set; }

		[JsonProperty("worldName")]
		public string? WorldName { get; set; }

		[JsonProperty("dcName")]
		public string? DcName { get; set; }

		[JsonProperty("regionName")]
		public string? RegionName { get; set; }

		[JsonProperty("lastUploadTime")]
		public long LastUploadTime { get; set; }

		public DateTimeOffset LastUpload
		{
			get
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(LastUploadTime);
			}
		}

		[JsonProperty("entries")]
		public IList<MinimizedSale> Entries { get; set; }

		[JsonProperty("regularSaleVelocity")]
		public double RegularSaleVelocity { get; set; }

		[JsonProperty("nqSaleVelocity")]
		public double NqSaleVelocity { get; set; }

		[JsonProperty("hqSaleVelocity")]
		public double HqSaleVelocity { get; set; }

		[JsonProperty("stackSizeHistogram")]
		public Dictionary<int, int> StackSizeHistogram { get; set; }

		[JsonProperty("stackSizeHistogramNQ")]
		public Dictionary<int, int> StackSizeHistogramNq { get; set; }

		[JsonProperty("stackSizeHistogramHQ")]
		public Dictionary<int, int> StackSizeHistogramHq { get; set; }
	}

	public class MinimizedSale
	{
		[JsonProperty("hq")]
		public bool Hq { get; set; }

		[JsonProperty("pricePerUnit")]
		public long PricePerUnit { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }

		public DateTimeOffset DateTime
		{
			get
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(Timestamp);
			}
		}

		[JsonProperty("onMannequin")]
		public bool OnMannequin { get; set; }

		[JsonProperty("worldName")]
		public string? WorldName { get; set; }

		[JsonProperty("worldID")]
		public int? WorldId { get; set; }

		[JsonProperty("buyerName")]
		public string? BuyerName { get; set; }
	}
}
