using FlyingSnow.Contract.Base;
using FlyingSnow.Contract.Bill;
using FlyingSnow.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            //ManagerService service = new ManagerService();
            //var result = service.GetManagerByAccount("AA");

            //OnlineService onlineService = new OnlineService();
            //var result = onlineService.GetOnlineUserCount();

            //BillService billService = new BillService();
            //var queryObj = new QueryObject();
            //queryObj.BillCatagory = BillCatagorys.AllRemarked;
            //var result = billService.GetBillByQuery(queryObj);

            //BillStatisticsService billStatisticsService = new BillStatisticsService();
            //billStatisticsService.GetBillStatistics();

            //MonitorService monitorService = new MonitorService();
            //monitorService.GetMonitorResult(new MonitorQueryObj());
            //monitorService.GetMonitorResultDetail(new MonitorDetailQueryObj() { QueryMember = "DX61", QueryType = "l_game_XFBJL" });

            //ReportService reportService = new ReportService();
            //reportService.GetBillReport(new ReportQueryObj());

            //AllianceService allianceService = new AllianceService();
            //allianceService.GetAlliances(new AllianceQueryObj() { BallType = BallTypes.Football, SearchStr = "女足"});
            //allianceService.SetZeroScore(30712, false);
        }
    }
}
