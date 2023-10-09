using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Channels;

var helper = new FreeAtHomeHelper("00000000-0000-0000-0000-000000000000");

foreach (string device in (await helper.GetAllDeviceIDs()).DeviceIDs)
{
    var details = await helper.GetDeviceInformations(device);

    Console.Write(device);
    Console.Write(" - ");
    Console.Write(details.displayName);
    Console.Write(" - ");
    Console.Write(details.defect);
    Console.Write(" - ");
    Console.WriteLine(details.@interface);
}

public class DeviceListResponse
{
    [JsonProperty("00000000-0000-0000-0000-000000000000")]
    public List<string> DeviceIDs { get; set; }
}

public class DeviceDetails
{
    public string floor { get; set; }
    public string room { get; set; }
    public string @interface { get; set; }
    public string displayName { get; set; }
    public bool unresponsive { get; set; }
    public int unresponsiveCounter { get; set; }
    public bool defect { get; set; }
}

public class FreeAtHomeHelper
{
    HttpClient httpClient = new HttpClient();

    private string sysAP;

    public FreeAtHomeHelper(string sysAP)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic NDhlNDg3YjYtOGY4MC00YTM1LTg2ZjYtZDYwZWRmZmUxMzlhOlhCMzJQTzZfTDhuWGcz");
        this.sysAP = sysAP;
    }

    public async Task<DeviceListResponse> GetAllDeviceIDs()
    {
        var response = await httpClient.GetAsync("http://192.168.0.188/fhapi/v1/api/rest/devicelist");
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<DeviceListResponse>(responseContent)!;
    }

    public async Task<DeviceDetails> GetDeviceInformations(string deviceID)
    {
        var response = await httpClient.GetAsync($"http://192.168.0.188/fhapi/v1/api/rest/device/{sysAP}/{deviceID}");
        var responseContent = await response.Content.ReadAsStringAsync();

        var json = JObject.Parse(responseContent);

        var deviceObject = json.SelectToken($"{sysAP}.devices.{deviceID}");

        return deviceObject.ToObject<DeviceDetails>()!;
    }
}