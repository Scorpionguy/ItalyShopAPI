using ItalyShopAPI.Data;

namespace ItalyShopAPI.Services
{
    public class LogService : ILogService
    {
        private readonly ItalyShopDbContext _dbContext;

        public LogService(ItalyShopDbContext db) => _dbContext = db;
        async public Task AddLog(string message, string type, int employeeId)
        {
            await _dbContext.Log.AddAsync(new Models.Logs()
            {
                idEmpFk = employeeId,
                action = type + ": " + message,
                logDate = DateTime.Now.Date,
                logTime = DateTime.Now.TimeOfDay
            });
            Console.WriteLine("Зафиксировано");
            //switch (type)
            //{
            //    case "Добавить":
            //        await _dbContext.Log.AddAsync(new Models.Logs()
            //        {
            //            idEmpFk = employeeId,
            //            action = type + ": " + message,
            //            logDate = DateTime.Now.Date,
            //            logTime = DateTime.Now.TimeOfDay
            //        });
            //        break;

                    //если использовать текущий адд то и свитч можно нахуй убрать, посмотреть потом как будет лучше


                //case "Удалить":
                //    await _dbContext.Log.AddAsync(new Models.Logs()
                //    {
                //        idEmpFk = employeeId,
                //        action = "Удалено: " + message,
                //        logDate = DateTime.Now.Date,
                //        logTime = DateTime.Now.TimeOfDay
                //    });
                //    break;
                //case "Обновить":
                //    await _dbContext.Log.AddAsync(new Models.Logs()
                //    {
                //        idEmpFk = employeeId,
                //        action = "Удалено: " + message,
                //        logDate = DateTime.Now.Date,
                //        logTime = DateTime.Now.TimeOfDay
                //    });
                //    break;
            //}
        }
    }
}
