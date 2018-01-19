using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeesMoneyScrap
{
    public class MyScrapeDbContext  : DbContext
    {
        public MyScrapeDbContext():base()
        {
            
        }
       public DbSet<ScrapeTable> ScrapeTables { get; set; }
    }
}
