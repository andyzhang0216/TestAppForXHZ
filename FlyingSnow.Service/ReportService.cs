using FlyingSnow.Contract.Base;
using FlyingSnow.Contract.Bill;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FlyingSnow.Service
{
    public class ReportService
    {
        public void GetBillReport(ReportQueryObj queryObj)
        {
            try
            {
                using (var ctx = new BillDBContext())
                {
                    var predicate = PredicateBuilder.True<Bill>();
                    switch (queryObj.QueryType)
                    {
                        case ReportQueryType.Default:
                            AddDatetimeCondition(ref predicate, queryObj);
                            break;
                        case ReportQueryType.All:
                        case ReportQueryType.Uncalculate:
                        case ReportQueryType.Calculated:
                            break;
                    }

                    Func<Bill, bool> query = predicate.Compile();
                    var collectionQuery = ctx.Bills.Where(query);

                    #region Query Obj
                    var resultQuery = from b in collectionQuery
                                      group b by new { b.Majordomo, b.Status } into g
                                      orderby g.Key.Majordomo, g.Key.Status //descending
                                      select new ReportResultObj
                                      {
                                          Majordomo = g.Key.Majordomo,
                                          IdCount = g.Key.Status != 0 ? 0 : g.Count(),
                                          PublicPoint = Convert.ToDouble(g.Sum(m => m.PublicPoint)),
                                          BetMoney = Convert.ToDouble(g.Sum(m => m.BetMoney)),
                                          BetMoneyGame = Convert.ToDouble(g.Where(m => !(m.GameType == "b_vd" || m.GameType == "b_dz" || m.MemberResult == null || m.MemberResult == 0)).Sum(m => m.EffectiveBetOfMember)),
                                          MemberResult = Convert.ToDouble(g.Sum(m => m.MemberResult)),
                                          CompanyResult = Convert.ToDouble(g.Sum(m => m.CompanyResult)),
                                          EffectiveBetOfMajordomo = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfMajordomo)),
                                          EffectiveBetOfBigPartner = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfBigPartner)),
                                          EffectiveBetOfPartner = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfPartner)),
                                          EffectiveBetOfGeneralAgency = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfGeneralAgency)),
                                          EffectiveBetOfAgency = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfAgency)),
                                          EffectiveBetOfMember = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfMember)),
                                          RefundMember = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundAmount / 10000 * 100)) / 100),
                                          RefundMajordomo = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundMajordomo / 10000 * (100 - m.OccupyByMajordomo))) / 100),
                                          RefundBigPartner = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundBigPartner / 10000 * (100 - m.OccupyByBigPartner))) / 100),
                                          RefundPartner = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundPartner / 10000 * (100 - m.OccupyByPartner))) / 100),
                                          RefundGeneralAgency = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundGeneralAgency / 10000 * (100 - m.OccupyByGeneralAgency))) / 100),
                                          RefundAgency = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundAgency / 10000 * (100 - m.OccupyByAgency))) / 100),
                                          Nocc00 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByMajordomo == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMajordomo / ((100 - m.OccupyByMajordomo) / 100) * 100)) / 100),
                                          Nocc01 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByBigPartner == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfBigPartner / ((100 - m.OccupyByBigPartner) / 100) * 100)) / 100),
                                          Nocc02 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByPartner == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfPartner / ((100 - m.OccupyByPartner) / 100) * 100)) / 100),
                                          Nocc03 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByGeneralAgency == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfGeneralAgency / ((100 - m.OccupyByGeneralAgency) / 100) * 100)) / 100),
                                          Nocc04 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByAgency == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfAgency / ((100 - m.OccupyByAgency) / 100) * 100)) / 100),
                                          BetMoneyCount = g.Where(m => m.BetMoney > 0 && m.Status == 0).Select(m => m.Member).Distinct().Count(),
                                          NewDate = Convert.ToDateTime(g.Max(m => m.TransferDate))
                                      };
                    #endregion

                    var result = resultQuery.ToList();

                    foreach (var a in result)
                    {
                        Console.WriteLine(a.Majordomo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetParlayBillReport(ReportQueryObj queryObj)
        {
            try
            {
                using (var ctx = new BillDBContext())
                {
                    var predicate = PredicateBuilder.True<ParlayBill>();

                    Func<ParlayBill, bool> query = predicate.Compile();
                    var collectionQuery = ctx.ParlayBills.Where(query);

                    #region Query Obj
                    var resultQuery = from b in collectionQuery
                                      group b by new { b.Majordomo, b.Status } into g
                                      orderby g.Key.Majordomo, g.Key.Status //descending
                                      select new ReportResultObj
                                      {
                                          Majordomo = g.Key.Majordomo,
                                          IdCount = g.Key.Status != 0 ? 0 : g.Count(),
                                          PublicPoint = Convert.ToDouble(g.Sum(m => m.PublicPoint)),
                                          BetMoney = Convert.ToDouble(g.Sum(m => m.BetMoney)),
                                          BetMoneyGame = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfMember)),
                                          MemberResult = Convert.ToDouble(g.Sum(m => m.MemberResult)),
                                          CompanyResult = Convert.ToDouble(g.Sum(m => m.CompanyResult)),
                                          EffectiveBetOfMajordomo = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfMajordomo)),
                                          EffectiveBetOfBigPartner = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfBigPartner)),
                                          EffectiveBetOfPartner = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfPartner)),
                                          EffectiveBetOfGeneralAgency = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfGeneralAgency)),
                                          EffectiveBetOfAgency = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfAgency)),
                                          EffectiveBetOfMember = Convert.ToDouble(g.Sum(m => m.EffectiveBetOfMember)),
                                          RefundMember = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundAmount / 10000 * 100)) / 100),
                                          RefundMajordomo = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundMajordomo / 10000 * (100 - m.OccupyByMajordomo))) / 100),
                                          RefundBigPartner = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundBigPartner / 10000 * (100 - m.OccupyByBigPartner))) / 100),
                                          RefundPartner = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundPartner / 10000 * (100 - m.OccupyByPartner))) / 100),
                                          RefundGeneralAgency = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundGeneralAgency / 10000 * (100 - m.OccupyByGeneralAgency))) / 100),
                                          RefundAgency = g.Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMember * m.RefundAgency / 10000 * (100 - m.OccupyByAgency))) / 100),
                                          Nocc00 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByMajordomo == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfMajordomo / ((100 - m.OccupyByMajordomo) / 100) * 100)) / 100),
                                          Nocc01 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByBigPartner == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfBigPartner / ((100 - m.OccupyByBigPartner) / 100) * 100)) / 100),
                                          Nocc02 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByPartner == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfPartner / ((100 - m.OccupyByPartner) / 100) * 100)) / 100),
                                          Nocc03 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByGeneralAgency == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfGeneralAgency / ((100 - m.OccupyByGeneralAgency) / 100) * 100)) / 100),
                                          Nocc04 = g.Where(m => !(m.GameType == "b_dz" || m.OccupyByAgency == 100)).Sum(m => Math.Floor(Convert.ToDouble(m.EffectiveBetOfAgency / ((100 - m.OccupyByAgency) / 100) * 100)) / 100),
                                          BetMoneyCount = g.Where(m => m.BetMoney > 0 && m.Status == 0).Select(m => m.Member).Distinct().Count(),
                                          NewDate = Convert.ToDateTime(g.Max(m => m.TransferDate))
                                      };
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddDatetimeCondition(ref Expression<Func<Bill, bool>> predicate, ReportQueryObj queryObj)
        {
            if (queryObj.QueryTimeType == QueryTimeType.TransferDate)
            {
                predicate = predicate.And(p => p.TransferDate >= queryObj.QueryStart && p.TransferDate <= queryObj.QueryEnd);
            }
            else
            {
                predicate = predicate.And(p => p.BetTime >= queryObj.QueryStart && p.BetTime <= queryObj.QueryEnd);
            }
        }

        private string GetManagersByAdmin(string Operator)
        {
            try
            {
                ManagerService managerService = new ManagerService();
                return managerService.GetManagerByAccount(Operator).SearchableMajordomo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Manager GetQueryUserManager(string queryUser)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    return ctx.Managers.Where(m => m.Account.Equals(queryUser, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    public class ReportQueryObj
    {
        public bool IsBillTable { get; set; } = true;

        public bool IsLowerPermission { get; set; } = true;
        public string Operator { get; set; }

        public string QueryUser { get; set; }

        public ReportQueryType QueryType { get; set; }
        public QueryTimeType QueryTimeType { get; set; }
        public DateTime? QueryStart { get; set; }
        public DateTime? QueryEnd { get; set; }

    }

    public enum ReportQueryType
    {
        Default = 0,
        All = 1,
        Uncalculate = 2,
        Calculated = 3,
        Recalculted = 7,
    }

    public enum QueryTimeType
    {
        TransferDate,
        BetTime
    }

    public class ReportResultObj
    {
        public string Majordomo { get; set; }
        public int IdCount { get; set; }
        public double PublicPoint { get; set; }
        public double BetMoney { get; set; }
        public double BetMoneyGame { get; set; }

        public double MemberResult { get; set; }
        public double CompanyResult { get; set; }
        public double EffectiveBetOfMajordomo { get; set; }
        public double EffectiveBetOfBigPartner { get; set; }
        public double EffectiveBetOfPartner { get; set; }
        public double EffectiveBetOfGeneralAgency { get; set; }
        public double EffectiveBetOfAgency { get; set; }
        //会员结果
        public double EffectiveBetOfMember { get; set; }
        //会员反水
        public double RefundMember { get; set; }
        public double RefundMajordomo { get; set; }
        public double RefundBigPartner { get; set; }
        public double RefundPartner { get; set; }
        public double RefundGeneralAgency { get; set; }
        public double RefundAgency { get; set; }

        public double Nocc00 { get; set; }
        public double Nocc01 { get; set; }
        public double Nocc02 { get; set; }
        public double Nocc03 { get; set; }
        public double Nocc04 { get; set; }
        public int BetMoneyCount { get; set; }
        public DateTime NewDate { get; set; }
    }
}
