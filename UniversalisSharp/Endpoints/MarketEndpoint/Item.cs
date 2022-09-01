using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public class Item
	{
		public Item()
		{
			Listings = new List<Listing>();
			RecentHistory = new List<RecentHistory>();
			WorldUploadTimes = new Dictionary<string, long>();
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

		[JsonProperty("lastUploadTime")]
		public long LastUploadTime { get; set; }

		public DateTimeOffset LastUpload
		{
			get
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(LastUploadTime);
			}
		}

		[JsonProperty("listings")]
		public IList<Listing> Listings { get; set; }

		[JsonProperty("recentHistory")]
		public IList<RecentHistory> RecentHistory { get; set; }

		[JsonProperty("dcName")]
		public string? DcName { get; set; }

		[JsonProperty("currentAveragePrice")]
		public double CurrentAveragePrice { get; set; }

		[JsonProperty("currentAveragePriceNQ")]
		public double CurrentAveragePriceNq { get; set; }

		[JsonProperty("currentAveragePriceHQ")]
		public double CurrentAveragePriceHq { get; set; }

		[JsonProperty("regularSaleVelocity")]
		public double RegularSaleVelocity { get; set; }

		[JsonProperty("nqSaleVelocity")]
		public double NqSaleVelocity { get; set; }

		[JsonProperty("hqSaleVelocity")]
		public double HqSaleVelocity { get; set; }

		[JsonProperty("averagePrice")]
		public double AveragePrice { get; set; }

		[JsonProperty("averagePriceNQ")]
		public double AveragePriceNq { get; set; }

		[JsonProperty("averagePriceHQ")]
		public double AveragePriceHq { get; set; }

		[JsonProperty("minPrice")]
		public long MinPrice { get; set; }

		[JsonProperty("minPriceNQ")]
		public long MinPriceNq { get; set; }

		[JsonProperty("minPriceHQ")]
		public long MinPriceHq { get; set; }

		[JsonProperty("maxPrice")]
		public long MaxPrice { get; set; }

		[JsonProperty("maxPriceNQ")]
		public long MaxPriceNq { get; set; }

		[JsonProperty("maxPriceHQ")]
		public long MaxPriceHq { get; set; }

		[JsonProperty("stackSizeHistogram")]
		public Dictionary<int, int> StackSizeHistogram { get; set; }

		[JsonProperty("stackSizeHistogramNQ")]
		public Dictionary<int, int> StackSizeHistogramNq { get; set; }

		[JsonProperty("stackSizeHistogramHQ")]
		public Dictionary<int, int> StackSizeHistogramHq { get; set; }

		[JsonProperty("worldUploadTimes")]
		public Dictionary<string, long> WorldUploadTimes { get; set; }
	}

	public class Listing
	{
		public Listing()
		{
			Materia = new List<Materia>();
		}

		[JsonProperty("lastReviewTime")]
		public long LastReviewTime { get; set; }

		public DateTimeOffset LastReview
		{
			get
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(LastReviewTime);
			}
		}

		[JsonProperty("pricePerUnit")]
		public long PricePerUnit { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("stainID")]
		public int StainId { get; set; }

		[JsonProperty("worldName")]
		public string? WorldName { get; set; }

		[JsonProperty("worldID")]
		public int? WorldId { get; set; }

		[JsonProperty("creatorName")]
		public string? CreatorName { get; set; }

		[JsonProperty("creatorID")]
		public string? CreatorId { get; set; }

		[JsonProperty("hq")]
		public bool Hq { get; set; }

		[JsonProperty("isCrafted")]
		public bool IsCrafted { get; set; }

		[JsonProperty("listingID")]
		public string? ListingId { get; set; }

		[JsonProperty("materia")]
		public IList<Materia> Materia { get; set; }

		[JsonProperty("onMannequin")]
		public bool OnMannequin { get; set; }

		[JsonProperty("retainerCity")]
		public int RetainerCity { get; set; }

		[JsonProperty("retainerID")]
		public string? RetainerId { get; set; }

		[JsonProperty("retainerName")]
		public string? RetainerName { get; set; }

		[JsonProperty("sellerID")]
		public string? SellerId { get; set; }

		[JsonProperty("total")]
		public long Total { get; set; }
	}

	public class Materia
	{
		[JsonProperty("slotID")]
		public int SlotId { get; set; }

		[JsonProperty("materiaID")]
		public int MateriaId { get; set; }
	}

	public class RecentHistory
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

		[JsonProperty("total")]
		public long Total { get; set; }
	}
}