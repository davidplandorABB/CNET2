using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTextGUI.Model
{
    /// <summary>
    /// Result of frequential analysis from given source
    /// </summary>
    internal class StatResult
    {
        public string Source { get; set; }

        /// <summary>
        /// 10 most common words in source
        /// </summary>
        public Dictionary<string,int> keyValuePairs { get; set; }

    }
}
