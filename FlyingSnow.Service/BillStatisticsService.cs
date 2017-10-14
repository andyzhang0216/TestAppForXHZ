using FlyingSnow.Contract.Boss;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class BillStatisticsService
    {
        public void GetBillStatistics()
        {
            try
            {
                using (var ctx = new BossDBContext())
                {
                    List<BillStatistics> list = ctx.BillStatistics.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
