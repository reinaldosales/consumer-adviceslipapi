using Consumer.AdviceSlip.Data;
using Consumer.AdviceSlip.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkerServicePlusEFCore.Services
{
    public class DbHelper
    {
        private ApplicationDbContext _dbContext;

        private DbContextOptions<ApplicationDbContext> GetAllOptions()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);

            return optionsBuilder.Options;
        }

        public void SaveSlip(Slip slip)
        {
            using (_dbContext = new ApplicationDbContext(GetAllOptions()))
            {
                _dbContext.Add(slip);
                _dbContext.SaveChanges();
            }
        }

        public Slip GetAdviceById(int id)
        {
            using(_dbContext = new ApplicationDbContext(GetAllOptions()))
            {

                var advice = _dbContext.Slip.FirstOrDefault(x => x.AdviceSlipId == id);

                return advice;
            }
        }
    }
}
