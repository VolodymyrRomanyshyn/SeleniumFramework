using System.Collections.Generic;

namespace Framework.BrowserSettings
{
    class DefaultConfiguration
    {
        private static Dictionary<string, Dictionary<string, string>> KeyValuePairs { get; } = new Dictionary<string, Dictionary<string, string>>
        {
            { "SeleniumSettings", new Dictionary<string, string>
                {
                    { "Browser",            "CH" },
                    { "TimeWait",           "20" },
                    { "ReportTimeWait",     "60" }
                }
            }
        };
        // returns result or null
        public static ValueSection GetSection(string Section) => KeyValuePairs.TryGetValue(Section, out Dictionary<string, string> result) ? new ValueSection(result) : null;
    }

    class ValueSection
    {
        private Dictionary<string, string> _dictionary;
        public ValueSection(Dictionary<string, string> Dictionary) => _dictionary = Dictionary;
        public string this[string Parameter] => _dictionary.TryGetValue(Parameter, out string result) ? result : null;
    }
}
