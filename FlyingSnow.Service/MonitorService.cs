using FlyingSnow.Contract.Base;
using FlyingSnow.Contract.Bill;
using FlyingSnow.Contract.Old;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class MonitorService
    {
        public void GetMonitorResult(MonitorQueryObj queryObj)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append("select t.*, m.f_peril as per, m.f_gamemode as gamemode, m.f_enterdate as f_loginintime, m.f_time as f_lastbilltime from (");

                    Dictionary<string, List<string>> tempDic = new Dictionary<string, List<string>>();
                    foreach (var pair in queryObj.GameAmountDic)
                    {
                        if (!tempDic.ContainsKey(pair.Value))
                        {
                            tempDic.Add(pair.Value, new List<string>() { pair.Key });
                        }
                        else
                        {
                            tempDic[pair.Value].Add(pair.Key);
                        }
                    }
                    string dateWhere = null;
                    if (queryObj.Start == queryObj.End)
                    {
                        dateWhere = string.Format("(f_date = '{0}') and ", "2017/9/27 0:00:00");
                    }
                    else
                    {
                        dateWhere = string.Format("(f_date between '{0}' and '{1}') and ", queryObj.Start, queryObj.End);
                    }
                    if (queryObj.GameAmountDic.Count == 15 && tempDic.Count == 1)
                    {
                        builder.Append("select B.f_member, M.f_jsjksee as f_Issee, M.f_jsjkbz as f_bz, M.f_createtime as f_createtime ,sum(f_money) as money,sum(f_mresult) as mresult,f_type,f_typ from {0} as B with(nolock) left join t_MemExpansion as M with(nolock) on B.f_member = M.f_member where ");
                        builder.Append(dateWhere);
                        builder.Append("f_del=0 and ");
                        builder.AppendFormat("(f_typ = 'b_vd' and f_type not in ('l_game_jkds', 'l_game_ptfs', 'l_game_tyjlbx', 'l_game_xhylj', 'l_game_ckhllb', 'l_game_ckyh','l_game_lajkds','l_game_lads','l_game_birthday')) group by B.f_member,f_type,f_typ,M.f_jsjksee, M.f_jsjkbz, M.f_createtime having sum(f_mresult)>= {0} ", tempDic.First().Key);
                    }
                    else
                    {
                        List<string> tempTableSql = new List<string>();
                        foreach (var pair in tempDic)
                        {
                            StringBuilder tempTBuilder = new StringBuilder();
                            tempTBuilder.AppendFormat("select B.f_member, M.f_jsjksee as f_Issee, M.f_jsjkbz as f_bz, M.f_createtime as f_createtime ,sum(f_money) as money,sum(f_mresult) as mresult,f_type,f_typ from {0} as B with(nolock) left join t_MemExpansion as M with(nolock) on B.f_member = M.f_member where ", " oldbase26.ts111_old.dbo.t_oldbill");
                            tempTBuilder.Append(dateWhere);
                            tempTBuilder.Append("f_del=0 and ");

                            if (pair.Value.Count == 1)
                            {
                                tempTBuilder.AppendFormat("f_type ='{0}' group by B.f_member,f_type,f_typ,M.f_jsjksee, M.f_jsjkbz, M.f_createtime having sum(f_mresult)>= {1} ", pair.Value.First(), pair.Key);
                            }
                            else
                            {
                                tempTBuilder.AppendFormat("f_type in ('{0}') group by B.f_member,f_type,f_typ,M.f_jsjksee, M.f_jsjkbz, M.f_createtime having sum(f_mresult)>= {1} ", string.Join("','", pair.Value), pair.Key);
                            }
                            tempTableSql.Add(tempTBuilder.ToString());
                        }
                        builder.Append(string.Join("union ", tempTableSql));
                    }
                    builder.Append(") t, t_member m With(NOLOCK) where m.f_accounts=t.f_member order by f_lastbilltime desc;");
                    var query = ctx.Database.SqlQuery<TempMonitorResult>(builder.ToString());
                    var result = query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<double> GetMonitorResultDetail(MonitorDetailQueryObj mdQueryObj)
        {
            try
            {
                double todayResult, currentMonthResult, lastMonthResult;
                #region Today
                using (var ctx = new BillDBContext())
                {
                    var predicate = PredicateBuilder.True<Bill>();
                    if (mdQueryObj.QueryType.ToLower().Contains("bjl"))//百家乐
                    {
                        predicate = predicate.And(p => (p.BetType.Equals("l_game_MPBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_XFBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_ZRBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_BJL", StringComparison.OrdinalIgnoreCase)));
                    }
                    else if (mdQueryObj.QueryType.ToLower().Contains("tb"))
                    {
                        predicate = predicate.And(p => p.BetType.Equals("l_game_TB", StringComparison.OrdinalIgnoreCase) ||
                                                       p.BetType.Equals("l_game_XFTB", StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        predicate = predicate.And(p => p.BetType.Equals(mdQueryObj.QueryType, StringComparison.OrdinalIgnoreCase));
                    }
                    predicate = predicate.And(p => p.Status == 0);
                    predicate = predicate.And(p => p.Member.Equals(mdQueryObj.QueryMember, StringComparison.OrdinalIgnoreCase));
                    if (DateTime.Now.Hour < 12)
                    {
                        predicate = predicate.And(p => p.TransferDate == DateTime.Today);
                    }
                    else
                    {
                        predicate = predicate.And(p => p.TransferDate == DateTime.Today.AddDays(1));
                        //predicate = predicate.And(p => p.TransferDate == new DateTime(2017, 9, 28));
                    }
                    Func<Bill, bool> query = predicate.Compile();
                    todayResult = Convert.ToDouble(ctx.Bills.Where(query).Sum(b => b.MemberResult));
                }
                #endregion

                #region Current Month
                double temp1 = 0, temp2 = 0;
                DateTime tempNow = DateTime.Now;
                if (tempNow.Hour <= 12)
                {
                    DateTime transferDate;
                    using (var ctx = new BaseDBContext())
                    {
                        var date = ctx.Transfers.Max(t => t.Date);
                        transferDate = Convert.ToDateTime(date);
                    }
                    if (tempNow > transferDate)
                    {
                        using (var ctx = new BillDBContext())
                        {
                            var query = ctx.Database.SqlQuery<double?>("select sum(OB.f_mresult) as mresult from BILLBASE26.ts111_bill.dbo.t_bill AS OB with(nolock) where OB.f_del=0 and OB.f_member = 'DX61' and (OB.f_type = 'l_game_MPBJL' or OB.f_type = 'l_game_XFBJL' or OB.f_type = 'l_game_ZRBJL'  or OB.f_type = 'l_game_BJL') and OB.f_date between '2017/10/13 0:00:00' and '2017/10/13 0:00:00' ");
                            temp1 = Convert.ToDouble(query.FirstOrDefault());
                        }
                    }
                }
                using (var ctx = new OldDBContext())
                {
                    var predicate = PredicateBuilder.True<OldBill>();
                    if (mdQueryObj.QueryType.ToLower().Contains("bjl"))//百家乐
                    {
                        predicate = predicate.And(p => (p.BetType.Equals("l_game_MPBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_XFBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_ZRBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_BJL", StringComparison.OrdinalIgnoreCase)));
                    }
                    else if (mdQueryObj.QueryType.ToLower().Contains("tb"))
                    {
                        predicate = predicate.And(p => p.BetType.Equals("l_game_TB", StringComparison.OrdinalIgnoreCase) ||
                                                       p.BetType.Equals("l_game_XFTB", StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        predicate = predicate.And(p => p.BetType.Equals(mdQueryObj.QueryType, StringComparison.OrdinalIgnoreCase));
                    }
                    predicate = predicate.And(p => p.Status == 0);
                    predicate = predicate.And(p => p.Member.Equals(mdQueryObj.QueryMember, StringComparison.OrdinalIgnoreCase));
                    DateTime Time1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime Time2 = Time1.AddMonths(1).AddDays(-1);
                    predicate = predicate.And(p => p.TransferDate >= Time1 && p.TransferDate <= Time2);

                    Func<OldBill, bool> query = predicate.Compile();
                    temp2 = Convert.ToDouble(ctx.OldBills.Where(query).Sum(b => b.MemberResult));
                }
                currentMonthResult = temp1 + temp2;
                #endregion

                #region Last Month
                using (var ctx = new OldDBContext())
                {
                    var predicate = PredicateBuilder.True<OldBill>();
                    if (mdQueryObj.QueryType.ToLower().Contains("bjl"))//百家乐
                    {
                        predicate = predicate.And(p => (p.BetType.Equals("l_game_MPBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_XFBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_ZRBJL", StringComparison.OrdinalIgnoreCase) ||
                                                        p.BetType.Equals("l_game_BJL", StringComparison.OrdinalIgnoreCase)));
                    }
                    else if (mdQueryObj.QueryType.ToLower().Contains("tb"))
                    {
                        predicate = predicate.And(p => p.BetType.Equals("l_game_TB", StringComparison.OrdinalIgnoreCase) ||
                                                       p.BetType.Equals("l_game_XFTB", StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        predicate = predicate.And(p => p.BetType.Equals(mdQueryObj.QueryType, StringComparison.OrdinalIgnoreCase));
                    }
                    predicate = predicate.And(p => p.Status == 0);
                    predicate = predicate.And(p => p.Member.Equals(mdQueryObj.QueryMember, StringComparison.OrdinalIgnoreCase));
                    DateTime Time1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    DateTime Time2 = Time1.AddMonths(1).AddDays(-1);
                    predicate = predicate.And(p => p.TransferDate >= Time1 && p.TransferDate <= Time2);

                    Func<OldBill, bool> query = predicate.Compile();
                    lastMonthResult = Convert.ToDouble(ctx.OldBills.Where(query).Sum(b => b.MemberResult));
                }
                #endregion

                return new List<double>() { todayResult, currentMonthResult, lastMonthResult };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TempMonitorResult
    {
        public string f_member { get; set; }
        public Nullable<byte> f_bz { get; set; }
        public Nullable<int> f_Issee { get; set; }
        public DateTime? f_createtime { get; set; }
        public double money { get; set; }
        public double mresult { get; set; }
        public string f_type { get; set; }
        public string f_typ { get; set; }
        public Nullable<int> per { get; set; } //f_peril
        public Nullable<int> gamemode { get; set; } //f_gamemode 真人电子游戏模式值
        public Nullable<System.DateTime> f_loginintime { get; set; }//f_enterdate
        public Nullable<System.DateTime> f_lastbilltime { get; set; }//f_time
    }
}
