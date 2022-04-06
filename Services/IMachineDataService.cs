using A17MMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace A17MMS.Services
{
    public interface IMachineDataService
    {
        Task<IEnumerable<Machine>> GetMachines();
        Task<Machine> AddMachine(CreateMachineDto createMachine);
        Task DeleteMachine(string machineId);
        Task UpdateMachine(string machineId, UpdateMachineDto updateMachine);
    }
}
