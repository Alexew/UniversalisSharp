using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalisSharp.Test
{
	public class BaseTests
	{
		public readonly UniversalisClient client;

		public const string DataCenter = "Chaos";
		public const int ItemId = 37775;
		public const int ItemId2 = 37776;

		public BaseTests()
		{
			client = new UniversalisClient();
		}
	}
}
