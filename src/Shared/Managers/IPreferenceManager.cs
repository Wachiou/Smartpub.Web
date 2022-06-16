using MVWorkflows.Shared.Settings;
using System.Threading.Tasks;
using MVWorkflows.Shared.Wrapper;

namespace MVWorkflows.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}