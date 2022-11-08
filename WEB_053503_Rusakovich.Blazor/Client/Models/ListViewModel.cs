using System.Text.Json.Serialization;

namespace WEB_053503_Rusakovich.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } 
        [JsonPropertyName("name")]
        public string Name { get; set; } 
    }

}
