using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Config
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri ApplicationUrl { get; set; }
        public float? TimeoutInterval { get; set; }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Safari,
        EdgeChromium
    }
}
