using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a video in Max Messenger.
/// </summary>
public class MediaResponse
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("token")]
    public required string Token { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("urls")]
    public required Dictionary<string, string> Urls { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public Thumbnail? Thumbnail { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public TimeSpan DurationTime => TimeSpan.FromMilliseconds(Duration);
}

/// <summary>
/// 
/// </summary>
public class Thumbnail
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}


//{
//    "token": "f9LHodD0cOJPNBcquUTBVpG3Zy-YDxwW968v0bUwGPonwfxJqJK7Kxp7pudLLGn-FoB8iv2_6KyWAR_LuksO",
//    "width": 720,
//    "height": 1280,
//    "duration": 18848,
//    "urls": {
//        "mp4_720": "http://vd551.okcdn.ru/?expires=1775646892281&srcIp=10.205.36.147&pr=95&srcAg=UNKNOWN&ms=185.226.55.61&type=3&sig=uvnEQ6V9Wpo&ct=0&urls=45.136.21.38&clientType=11&appId=1248243456&id=12739016985203"
//    },
//    "thumbnail": {
//    "url": "https://pimg.mycdn.me/getImage?disableStub=true&type=PREPARE&url=https%3A%2F%2Fiv.okcdn.ru%2FvideoPreview%3Fid%3D12739016985203%26type%3D39%26idx%3D0%26tkn%3DovSwO97FlIFYCMe627Yh0XYKYJk&signatureToken=mHyPfERs6F06cDXVBj2nCQ"
//    }
//}
