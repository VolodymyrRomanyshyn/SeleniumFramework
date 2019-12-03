using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Framework.BrowserSettings
{
    public class ConfigReader
    {
        private static IConfiguration config;

        protected static IConfiguration Config => config ?? (config = new ConfigurationBuilder()
            .SetBasePath(GetPath)
            .AddJsonFile("appsettings.json").Build());

        /// <summary>
        /// Returns Enum Browser from appsettings.json file or Enviroment Browser
        /// </summary>
        public static Browsers Browser =>
            Enum.TryParse(Environment.GetEnvironmentVariable("Browser"), true, out Browsers EnvironmentEnum) ? EnvironmentEnum :
            Enum.TryParse(Config.GetSection("SeleniumSettings")["browser"], true, out Browsers JsonEnum) ? JsonEnum :
            Enum.TryParse(DefaultConfiguration.GetSection("SeleniumSettings")["browser"], true, out Browsers DefaultEnum) ? DefaultEnum :
            Browsers.None;

        /// <summary>
        /// Returns TimeWait for Elements implemented from BaseElement
        /// </summary>
        public static TimeSpan TimeWait => GetTimeSpanFromseconds("SeleniumSettings", "TimeWait");

        /// <summary>
        /// Returns TimeWait for Elements imblemented from ReportBaseElement
        /// </summary>
        public static TimeSpan ReportTimeWait => GetTimeSpanFromseconds("SeleniumSettings", "ReportTimeWait");

        // returns path:
        // project\bin\Debug\netcoreapp2.1\
        // or
        // project
        private static string GetPath =>
            File.Exists($@"{Directory.GetCurrentDirectory()}\appsettings.json") ?
            Directory.GetCurrentDirectory() :
            Directory.GetCurrentDirectory() + @"\..\..\..";

        /// <summary>
        ///  Returns and remembers TimeSpan parameter from appsettings.json
        ///  Returns default if file not contains defired key and value 
        /// </summary>
        /// <param name="Section"></param> section on json file
        /// <param name="Parameter"></param> paramenter on json file
        /// <returns></returns>
        private static TimeSpan GetTimeSpanFromseconds(string Section, string Parameter) =>
            Environment.GetEnvironmentVariable(Parameter) != null ?
            TimeSpan.FromSeconds(int.Parse(Environment.GetEnvironmentVariable(Parameter))) :
            Config.GetSection(Section)[Parameter] != null ?
            TimeSpan.FromSeconds(int.Parse(Config.GetSection(Section)[Parameter])) :
            TimeSpan.FromSeconds(int.Parse(DefaultConfiguration.GetSection(Section)[Parameter]));
    }
}
