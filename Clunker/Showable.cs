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
    abstract class AbstractShowable: Showable
    {
        
        protected string showBySequence(IEnumerable<object> members) {
            var shownMembers = showSequence(members);
            var shownComposition = string.Join(", ", shownMembers);
            var typeName = this.GetType().ToString();
            return string.Format("{0}({1})", typeName, shownComposition);
        }

        protected string showParameters(params object[] members) {
            return showBySequence(members);
        }

        protected IEnumerable<string> showSequence(IEnumerable<object> sequence) {
            return from element in sequence select showElement(element);
        }

        protected string showElement(object element) {
            return element.ToString();
        }
            
        public string show() {
            return this.ToString();
        }
    }

}
