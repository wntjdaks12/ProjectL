using Newtonsoft.Json;

public class IconInfo : Data
{
    [JsonProperty]
    public string Path { get; private set; }
}
