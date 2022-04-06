using A17MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace A17MMS.Services
{
    public class MachineDataService : IMachineDataService
    {
        private readonly HttpClient httpClient;

        public MachineDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Machine> AddMachine(CreateMachineDto createMachine)
        {
            var json = new StringContent(JsonSerializer.Serialize(createMachine), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/machine", json);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Machine>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task DeleteMachine(string machineId)
        {
            await httpClient.DeleteAsync($"api/machine/{machineId}");
        }

        public async Task<IEnumerable<Machine>> GetMachines()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Machine>>
                (await httpClient.GetStreamAsync("api/machine"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateMachine(string machineId, UpdateMachineDto updateMachine)
        {
            var json = new StringContent(JsonSerializer.Serialize(updateMachine), Encoding.UTF8, "application/json");
            await httpClient.PutAsync($"api/machine/{machineId}", json);
            //if (response.IsSuccessStatusCode)
            //{
            //    return await JsonSerializer.DeserializeAsync<Machine>(await response.Content.ReadAsStreamAsync());
            //}
            //return null;
        }
    }
}