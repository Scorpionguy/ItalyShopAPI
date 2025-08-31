namespace ItalyShopAPI.Services
{
    public interface ILogService
    {
        public Task AddLog(string message, string action, int employeeId);
        //public Task RemoveLog(string message);
        //public Task<string> UpdateLog(string message);

    }
}
