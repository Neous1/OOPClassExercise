using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeesMoneyScrap
{
    public class ScrapeTable
    {
        public int Id { get; set; }
        public DateTime PullTime { get; set; }
        public string Symbol { get; set; }
        public string LastPrice { get; set; }
        public string Type { get; set; }
        public string ChangePerc { get; set; }
        public string Volume { get; set; }
        public string VolumeAvg { get; set; }

    }
}
