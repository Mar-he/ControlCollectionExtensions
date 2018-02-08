using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebExtensions
{
    public static class ControlCollectionExtensions
    {
		public static IEnumerable<T> GetControls<T>(this ControlCollection cCol,
			List<T> results,
			Func<T, bool> predicate) where T : WebControl
		{

			foreach (Control control in cCol)
			{
				if ((control is T && predicate == null) || (control is T && predicate != null && predicate((T)control)))
				{
					results.Add((T)control);
				}
				
				if (control.HasControls())
				{
					GetControls<T>(control.Controls, results, predicate);
				}
			}

			return results;
		}

		public static IEnumerable<T> GetControls<T>(this ControlCollection cCol) where T : WebControl
		{
			return cCol.GetControls(new List<T>(), null);
		}

		public static IEnumerable<T> GetControls<T>(this ControlCollection cCol, Func<T, bool> predicate) where T : WebControl
		{
			return cCol.GetControls(new List<T>(), predicate);
		}
	}
}
