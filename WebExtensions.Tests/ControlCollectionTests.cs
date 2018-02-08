using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xunit;

namespace WebExtensions.Tests
{
	public class ControlCollectionTests
	{
		const int ControlCount = 10;

		[Fact]
		public void PassingTest()
		{
			Assert.Equal(4, 2 + 2);
		}

		internal ControlCollection ArrangeControls()
		{
			Control ctrl = new Control();
			ControlCollection coll = ctrl.Controls;

			for (int i = 0; i < ControlCount; i++)
			{
				var button = new Button();
				button.Text = $"Button {i}";

				var literal = new Label {
					Text = $"Literal {i}"
				};

				if(i % 2 == 0)
				{
					button.Attributes["data-foo"] = "bar";
				}
				coll.Add(button);
				coll.Add(literal);
			}
			return coll;
		}
		[Fact]
		public void AssertCollectionContains10ItemsOfType()
		{
			var coll = ArrangeControls();
			var buttonCount = coll.GetControls<Button>().Count();
			var labelCount = coll.GetControls<Label>().Count();
			Assert.Equal(buttonCount, ControlCount);
			Assert.Equal(labelCount, ControlCount);
		}
		
		[Fact]
		public void QueryButtonsByAttribute()
		{
			var coll = ArrangeControls();
			var buttonCount = coll.GetControls<Button>( x => x.Attributes["data-foo"] == "bar").Count();
			Assert.Equal(5, buttonCount);

		}

	}
}
