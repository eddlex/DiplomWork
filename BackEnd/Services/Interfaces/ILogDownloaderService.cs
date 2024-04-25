using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ILogDownloaderService
    {
        Task<List<Log>> GetLog(LogPost model);
    }
}
