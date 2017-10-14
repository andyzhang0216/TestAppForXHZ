using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class OnlineService
    {
        public Dictionary<string, int> GetOnlineUserCount()
        {
            try
            {
                using (var ctx = new OnlineDBContext())
                {
                    var tempDate = DateTime.Now.AddMinutes(-20);
                    var managerCount = ctx.Onlines.Count(o => o.Catagory >= 4 && o.Catagory <= 8 && o.TimeNow > tempDate);
                    var memberCount = ctx.Onlines.Count(o => o.Catagory == 9 && o.TimeNow > tempDate);
                    return new Dictionary<string, int>()
                    {
                        { "Manager", managerCount },
                        { "Member", memberCount }
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
