using System.Text.Json.Serialization;

namespace MonoGame.Extended.TextureAtlases
{
    public class TexturePackerMeta
    {
        [JsonPropertyName("app")]
        public string App { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("size")]
        public TexturePackerSize Size { get; set; }

        [JsonPropertyName("scale"),JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public float Scale { get; set; }

        [JsonPropertyName("smartupdate")]
        public string SmartUpdate { get; set; }

        public override string ToString()
        {
            return Image;
        }
    }
}
