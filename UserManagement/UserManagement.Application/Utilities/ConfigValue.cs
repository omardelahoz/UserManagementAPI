using Microsoft.Extensions.Configuration;

namespace UserManagement.Application.Utilities
{
    internal static class ConfigValue
    {
        public static string GetConfiguration(string section, string? subSection = null)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationSection s = builder.Build().GetSection(section);
            if (!string.IsNullOrEmpty(subSection))
            {
                s = s.GetSection(subSection);
            }

            return s.Value!;
        }
    }
}
