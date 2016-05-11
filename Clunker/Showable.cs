using System;
using System.Collections.Generic;
using System.Linq;

namespace Clunker
{
	public interface Showable
	{
		string show();
	}

	// I don't think we need this, it should just resort to ToString...
	// Some of the most complicated code in VBEX was defShow.bas,
	// but if C# will do all that jazz for free then why waste my time,
	// or create difficult code to read.
	static class DefShow
	{
		public static string show(object obj)
		{
			return showElement(obj);
		}

		public static string showBySequence(object obj, IEnumerable<object> members)
		{
			var shownMembers = showSequence(members);
			var typeName = obj.GetType().ToString();
			return string.Format("{0}({1})", typeName, shownMembers);
		}

		public static string showParameters(object obj, params object[] members)
		{
			return showBySequence(obj, members);
		}

		private static string showSequence(IEnumerable<object> sequence)
		{
			var elements = from element in sequence
			               select showElement(element);
			return string.Join(", ", elements);
		}

		private static string showElement(object element)
		{
			if (isArray(element)) {
				return showArray((object[]) element);
			} else if (isShowable(element)) {
				Showable s = (Showable)element;
				return s.show();
			} else {
				return element.ToString();
			}
		}

		private static string showArray(object[] array)
		{
			var shownMembers = showSequence(array);
			var typeName = array.GetType().GetElementType().ToString();
			return string.Format("{0}[{1}]", typeName, shownMembers);
		}

		private static bool isShowable(object element) 
		{
			Type showType = typeof(Showable);
			Type elType = element.GetType();
			return showType.IsAssignableFrom(elType);
		}

		private static bool isArray(object element)
		{
			return element.GetType().IsArray;
		}
	}

}
