using UniversalisSharp;

namespace Example
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var client = new UniversalisClient();

			var items = client.Market.GetItemsData("Chaos", new int[] { 37775, 37776 }, hq: true).Result;
		}
	}
}