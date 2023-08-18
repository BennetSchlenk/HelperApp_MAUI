using HelperApp_MAUI.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace HelperApp_MAUI.DataService
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient httpClient;
        private readonly string baseAdress;
        private readonly string url;
        private readonly JsonSerializerOptions jasonSerializeOptions;

        public RestDataService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback += HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            httpClient = new HttpClient(handler);
            baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7263" : "https://localhost:7263";
            Debug.WriteLine("LOL DEVICE: " + DeviceInfo.Platform);
            url = $"{baseAdress}/api";
            jasonSerializeOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

        }

        public async Task AddToDoAsync(ToDo toDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access!");
                return;
            }

            try
            {
                string jasnToDo = JsonSerializer.Serialize<ToDo>(toDo, jasonSerializeOptions);
                StringContent content = new StringContent(jasnToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync($"{url}/todo", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Sucessfully created ToDo");
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response!");
                }
                return;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exeption: {e.Message}");
            }
        }

        public async Task DeleteToDoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access!");
                return;
            }

            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/todo/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Sucessfully Deleted ToDo");
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response!");
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exeption: {e.Message}");
            }

            return;
        }

        public async Task<List<ToDo>> GetAllToDosAsync()
        {
            List<ToDo> todos = new List<ToDo>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access!");
                return todos;
            }

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/todo");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    todos = JsonSerializer.Deserialize<List<ToDo>>(content, jasonSerializeOptions);
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response!");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exeption: {e.Message}");
            }

            return todos;
        }

        public async Task UpdateToDoAsync(ToDo toDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access!");
                return;
            }


            try
            {
                string jasnToDo = JsonSerializer.Serialize<ToDo>(toDo, jasonSerializeOptions);
                StringContent content = new StringContent(jasnToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync($"{url}/todo/{toDo.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Sucessfully Updated ToDo");
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response!");
                }
                return;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exeption: {e.Message}");
            }
        }
    }
}
