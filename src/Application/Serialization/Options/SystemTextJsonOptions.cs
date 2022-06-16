using System.Text.Json;
using MVWorkflows.Application.Interfaces.Serialization.Options;

namespace MVWorkflows.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}