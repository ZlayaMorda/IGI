using System.Text.Json.Serialization;

namespace WEB_053503_Rusakovich.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } 
        [JsonPropertyName("description")]
        public string Description { get; set; } 
        [JsonPropertyName("price")]
        public int Price { get; set; } 
        [JsonPropertyName("imageName")]
        public string ImageName { get; set; } 
    }
}
