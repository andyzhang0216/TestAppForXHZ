using FlyingSnow.Contract;
using FlyingSnow.Contract.Bill;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class BillService
    {
        public List<Bill> GetBillByQuery(QueryObject queryObj)
        {
            try
            {
                using (var ctx = new BillDBContext())
                {
                    var predicate = PredicateBuilder.True<Bill>();
                    if (queryObj.GameType != null)
                    {
                        predicate = predicate.And(p => p.GameType.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase));
                    }
                    if (queryObj.TransferDate != null)
                    {
                        predicate = predicate.And(p => p.TransferDate == queryObj.TransferDate);
                    }
                    else if (queryObj.BetTimes != null)
                    {
                        predicate = predicate.And(p => p.BetTime > queryObj.BetTimes[0] && p.BetTime < queryObj.BetTimes[1]);
                    }
                    if (queryObj.CalculateStatus != null)
                    {
                        if (queryObj.CalculateStatus == CalculateStatus.Calcuted)
                        {
                            predicate = predicate.And(p => p.CalculateStatus > 0);
                        }
                        else
                        {
                            predicate = predicate.And(p => p.CalculateStatus == (int)queryObj.CalculateStatus);
                        }
                    }
                    if (queryObj.BetType != null)
                    {
                        switch (queryObj.BetType)
                        {
                            case BetType.All:
                                predicate = predicate.And(p => !(p.GameType.Equals("b_dz", StringComparison.OrdinalIgnoreCase) && p.GameType.Equals("b_vd", StringComparison.OrdinalIgnoreCase)));
                                break;
                            case BetType.SpecialBet:
                                predicate = predicate.And(p => p.Alliance.IndexOf("特别投注") > 0);
                                break;
                            case BetType.Designated15Mins:
                                predicate = predicate.And(p => p.Alliance.IndexOf("特定15分钟") > 0);
                                break;
                        }
                    }
                    if (queryObj.BillCatagory != null)
                    {
                        switch (queryObj.BillCatagory)
                        {
                            case BillCatagorys.Available:
                            case BillCatagorys.GoalCanceled:
                            case BillCatagorys.ArbitrageCanceled:
                            case BillCatagorys.OrganizationBetCanceled:
                            case BillCatagorys.ExceptionCanceled:
                                predicate = predicate.And(p => p.Status == (int)queryObj.BillCatagory);
                                break;
                            case BillCatagorys.AllDeleteCanceled:
                                predicate = predicate.And(p => (p.Status >= 1 && p.Status <= 7) || (p.ExFlag & 128) > 0);
                                break;
                            case BillCatagorys.Deleted:
                                predicate = predicate.And(p => p.Status == 1 || (p.ExFlag & 128) > 0);
                                break;
                            case BillCatagorys.Danger:
                                predicate = predicate.And(p => p.MemberDangerLevel > 1 && p.MemberDangerLevel != 99);
                                break;
                            case BillCatagorys.AddWaterArbitrage:
                            case BillCatagorys.WashOwnedArbitrage:
                            case BillCatagorys.OrganizationBet:
                            case BillCatagorys.BorrowArbitrage:
                            case BillCatagorys.BeforeOpen:
                            case BillCatagorys.BeforeClose:
                            case BillCatagorys.HighChange:
                                predicate = predicate.And(p => p.RemarkFlag == Convert.ToInt16(queryObj.BillCatagory.StringValue()));
                                break;
                            case BillCatagorys.AllRemarked:
                                List<int> tempList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 16, 17, 18 };
                                predicate = predicate.And(p => tempList.Any(i => i == Convert.ToInt32(p.RemarkFlag)));
                                break;
                            case BillCatagorys.RefuseBet:
                            case BillCatagorys.RedCardCancel:
                                predicate = predicate.And(p => p.Status == Convert.ToInt16(queryObj.BillCatagory.StringValue()));
                                break;
                            case BillCatagorys.AllCanceled:
                                predicate = predicate.And(p => p.Status >= 2 && p.Status <= 7);
                                break;
                            case BillCatagorys.GeneralMember:
                                predicate = predicate.And(p => p.MemberDangerLevel == 99);
                                break;
                            case BillCatagorys.UnusualIP:
                                predicate = predicate.And(p => (p.ExFlag & 1) > 0);
                                break;
                            case BillCatagorys.BetConfirm:
                                predicate = predicate.And(p => (p.AffirmState & 1) > 0);
                                break;
                            case BillCatagorys.Remarked:
                                predicate = predicate.And(p => p.f_DCinfoID != null);
                                break;
                            default:
                                break;
                        }
                    }
                    if (queryObj.QueryCondition != null)
                    {
                        switch (queryObj.QueryCondition)
                        {
                            case QueryConditions.Member:
                                predicate = predicate.And(p => p.Member.Equals(queryObj.Member, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Agency:
                                predicate = predicate.And(p => p.Agency.Equals(queryObj.Agency, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.GeneralAgency:
                                predicate = predicate.And(p => p.GeneralAgency.Equals(queryObj.GeneralAgency, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Partner:
                                predicate = predicate.And(p => p.Partner.Equals(queryObj.Partner, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.BigPartner:
                                predicate = predicate.And(p => p.BigPartner.Equals(queryObj.BigPartner, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Majordomo:
                                predicate = predicate.And(p => p.Majordomo.Equals(queryObj.Majordomo, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.BillId:
                                predicate = predicate.And(p => p.BillId == queryObj.BillId);
                                break;
                            case QueryConditions.BillIP:
                                predicate = predicate.And(p => p.BillIP.Equals(queryObj.BillIP, StringComparison.OrdinalIgnoreCase));
                                break;
                        }
                    }
                    Func<Bill, bool> query = predicate.Compile();
                    return ctx.Bills.Where(query).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ParlayBill> GetParlayBillByQuery(QueryObject queryObj)
        {
            try
            {
                using (var ctx = new BillDBContext())
                {
                    var predicate = PredicateBuilder.True<ParlayBill>();

                    if (queryObj.GameType != null)
                    {
                        predicate = predicate.And(p => p.GameType.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName1.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName2.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName3.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName4.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName5.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName6.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName7.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName8.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase)
                                                    || p.GameTypeName9.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase));
                    }
                    if (queryObj.BillCatagory != null)
                    {
                        switch (queryObj.BillCatagory)
                        {
                            case BillCatagorys.Available:
                            case BillCatagorys.GoalCanceled:
                            case BillCatagorys.ArbitrageCanceled:
                            case BillCatagorys.OrganizationBetCanceled:
                            case BillCatagorys.ExceptionCanceled:
                                predicate = predicate.And(p => p.Status == (int)queryObj.BillCatagory);
                                break;
                            case BillCatagorys.AllDeleteCanceled:
                                predicate = predicate.And(p => (p.Status >= 1 && p.Status <= 7) || (p.ExFlag & 128) > 0);
                                break;
                            case BillCatagorys.Deleted:
                                predicate = predicate.And(p => p.Status == 1 || (p.ExFlag & 128) > 0);
                                break;
                            case BillCatagorys.Danger:
                                predicate = predicate.And(p => p.MemberDangerLevel > 1 && p.MemberDangerLevel != 99);
                                break;
                            case BillCatagorys.RefuseBet:
                            case BillCatagorys.RedCardCancel:
                                predicate = predicate.And(p => p.Status == Convert.ToInt16(queryObj.BillCatagory.StringValue()));
                                break;
                            case BillCatagorys.AllCanceled:
                                predicate = predicate.And(p => p.Status >= 2 && p.Status <= 7);
                                break;
                            case BillCatagorys.GeneralMember:
                                predicate = predicate.And(p => p.MemberDangerLevel == 99);
                                break;
                            case BillCatagorys.UnusualIP:
                                predicate = predicate.And(p => (p.ExFlag & 1) > 0);
                                break;
                            case BillCatagorys.BetConfirm:
                                predicate = predicate.And(p => (p.AffirmState & 1) > 0);
                                break;
                            case BillCatagorys.Remarked:
                                predicate = predicate.And(p => p.f_DCinfoID != null);
                                break;
                            default:
                                break;
                        }
                    }
                    bool flag = true;
                    #region 过关特殊逻辑
                    switch (queryObj.BetType)
                    {
                        case BetType.Parlay:
                            predicate = predicate.And(p => string.IsNullOrEmpty(p.GameTypeName1));
                            if (queryObj.GameType != GameTypes.All)
                            {
                                predicate = predicate.And(p => p.GameType.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase));
                                if (queryObj.QueryCondition == QueryConditions.GameNumber && !string.IsNullOrEmpty(queryObj.GameNumber))
                                {
                                    if (queryObj.BillCatagory == BillCatagorys.Demotion)
                                    {
                                        predicate = predicate.And(p => (p.BillParlay0.Equals(queryObj.GameNumber) && (p.Demotion & 1) > 0) ||
                                                                       (p.BillParlay1.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 1)) > 0) ||
                                                                       (p.BillParlay2.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 2)) > 0) ||
                                                                       (p.BillParlay3.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 3)) > 0) ||
                                                                       (p.BillParlay4.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 4)) > 0) ||
                                                                       (p.BillParlay5.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 5)) > 0) ||
                                                                       (p.BillParlay6.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 6)) > 0) ||
                                                                       (p.BillParlay7.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 7)) > 0) ||
                                                                       (p.BillParlay8.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 8)) > 0) ||
                                                                       (p.BillParlay9.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 9)) > 0));
                                    }
                                    else
                                    {
                                        predicate = predicate.And(p => p.BillParlay0.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay1.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay2.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay3.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay4.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay5.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay6.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay7.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay8.Equals(queryObj.GameNumber) ||
                                                                       p.BillParlay9.Equals(queryObj.GameNumber));
                                    }
                                    flag = false;
                                }

                            }
                            break;
                        case BetType.MixParlay:
                            predicate = predicate.And(p => !string.IsNullOrEmpty(p.GameTypeName1));
                            if (queryObj.GameType != GameTypes.All)
                            {
                                if (queryObj.QueryCondition == QueryConditions.GameNumber && !string.IsNullOrEmpty(queryObj.GameNumber))
                                {
                                    if (queryObj.BillCatagory == BillCatagorys.Demotion)
                                    {
                                        predicate = predicate.And(p => (p.GameType.Equals(queryObj.GameType.StringValue()) && p.BillParlay0.Equals(queryObj.GameNumber) && (p.Demotion & 1) > 0) ||
                                                                       (p.GameTypeName1.Equals(queryObj.GameType.StringValue()) && p.BillParlay1.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 1)) > 0) ||
                                                                       (p.GameTypeName2.Equals(queryObj.GameType.StringValue()) && p.BillParlay2.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 2)) > 0) ||
                                                                       (p.GameTypeName3.Equals(queryObj.GameType.StringValue()) && p.BillParlay3.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 3)) > 0) ||
                                                                       (p.GameTypeName4.Equals(queryObj.GameType.StringValue()) && p.BillParlay4.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 4)) > 0) ||
                                                                       (p.GameTypeName5.Equals(queryObj.GameType.StringValue()) && p.BillParlay5.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 5)) > 0) ||
                                                                       (p.GameTypeName6.Equals(queryObj.GameType.StringValue()) && p.BillParlay6.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 6)) > 0) ||
                                                                       (p.GameTypeName7.Equals(queryObj.GameType.StringValue()) && p.BillParlay7.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 7)) > 0) ||
                                                                       (p.GameTypeName8.Equals(queryObj.GameType.StringValue()) && p.BillParlay8.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 8)) > 0) ||
                                                                       (p.GameTypeName9.Equals(queryObj.GameType.StringValue()) && p.BillParlay9.Equals(queryObj.GameNumber) && (p.Demotion & (1 << 9)) > 0));
                                    }
                                    else
                                    {
                                        predicate = predicate.And(p => (p.GameType.Equals(queryObj.GameType.StringValue()) && p.BillParlay0.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName1.Equals(queryObj.GameType.StringValue()) && p.BillParlay1.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName2.Equals(queryObj.GameType.StringValue()) && p.BillParlay2.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName3.Equals(queryObj.GameType.StringValue()) && p.BillParlay3.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName4.Equals(queryObj.GameType.StringValue()) && p.BillParlay4.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName5.Equals(queryObj.GameType.StringValue()) && p.BillParlay5.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName6.Equals(queryObj.GameType.StringValue()) && p.BillParlay6.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName7.Equals(queryObj.GameType.StringValue()) && p.BillParlay7.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName8.Equals(queryObj.GameType.StringValue()) && p.BillParlay8.Equals(queryObj.GameNumber)) ||
                                                                       (p.GameTypeName9.Equals(queryObj.GameType.StringValue()) && p.BillParlay9.Equals(queryObj.GameNumber)));
                                    }
                                    flag = false;
                                }
                                else
                                {
                                    predicate = predicate.And(p => p.GameType.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName1.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName2.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName3.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName4.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName5.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName6.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName7.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName8.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase) ||
                                                                   p.GameTypeName9.Equals(queryObj.GameType.StringValue(), StringComparison.OrdinalIgnoreCase));
                                }
                            }
                            break;
                    }
                    #endregion

                    if (queryObj.QueryCondition != null)
                    {
                        switch (queryObj.QueryCondition)
                        {
                            case QueryConditions.Member:
                                predicate = predicate.And(p => p.Member.Equals(queryObj.Member, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Agency:
                                predicate = predicate.And(p => p.Agency.Equals(queryObj.Agency, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.GeneralAgency:
                                predicate = predicate.And(p => p.GeneralAgency.Equals(queryObj.GeneralAgency, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Partner:
                                predicate = predicate.And(p => p.Partner.Equals(queryObj.Partner, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.BigPartner:
                                predicate = predicate.And(p => p.BigPartner.Equals(queryObj.BigPartner, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.Majordomo:
                                predicate = predicate.And(p => p.Majordomo.Equals(queryObj.Majordomo, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.BillId:
                                predicate = predicate.And(p => p.BillId == queryObj.BillId);
                                break;
                            case QueryConditions.BillIP:
                                predicate = predicate.And(p => p.BillIP.Equals(queryObj.BillIP, StringComparison.OrdinalIgnoreCase));
                                break;
                            case QueryConditions.GameNumber:
                                if (flag)
                                {
                                    predicate = predicate.And(p => p.BillParlay0.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay1.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay2.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay3.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay4.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay5.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay6.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay7.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay8.Equals(queryObj.GameNumber) ||
                                                                   p.BillParlay9.Equals(queryObj.GameNumber));
                                }
                                break;
                        }
                    }

                    Func<ParlayBill, bool> query = predicate.Compile();
                    return ctx.ParlayBills.Where(query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetTransferTime()
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    var query = from t in ctx.Transfers
                                orderby t.Date
                                select t.Date;
                    return Convert.ToDateTime(query.First());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
