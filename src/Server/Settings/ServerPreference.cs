using System.Linq;
using MVWorkflows.Shared.Constants.Localization;
using MVWorkflows.Shared.Settings;

namespace MVWorkflows.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}