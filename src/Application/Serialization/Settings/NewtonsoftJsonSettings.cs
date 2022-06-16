
using MVWorkflows.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace MVWorkflows.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}