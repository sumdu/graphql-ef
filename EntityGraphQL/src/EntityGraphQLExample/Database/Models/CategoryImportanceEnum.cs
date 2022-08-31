using System.Text.Json.Serialization;

namespace EntityGraphQLExample.Database.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryImportanceEnum
    {
        Important,
        Regular
    }
}
