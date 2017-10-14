using FlyingSnow.Contract.Base;
using FlyingSnow.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Service
{
    public class ManagerService
    {
        public List<Manager> GetAllMajordomos(string searchUser)
        {
            try
            {
                if (GetAllPermission(searchUser))
                {
                    using (BaseDBContext ctx = new BaseDBContext())
                    {
                        #region Query & Convert
                        var result = from manager in ctx.Managers
                                     orderby manager.Account
                                     where manager.Catagory == 4
                                     select new
                                     {
                                         Id = manager.Id,
                                         Account = manager.Account,
                                         Title = manager.Title,
                                         ResidualCredit = manager.ResidualCredit,
                                         EnterAllow = manager.EnterAllow,
                                         Remark = manager.Remark,
                                         RemarkText = manager.RemarkText,

                                         AmericanBaseball = manager.AmericanBaseball,
                                         JapaneseBaseball = manager.JapaneseBaseball,
                                         TaiwaneseBaseball = manager.TaiwaneseBaseball,
                                         KoreanBaseball = manager.KoreanBaseball,
                                         Hockey = manager.Hockey,
                                         Basketball = manager.Basketball,
                                         ColorBall = manager.ColorBall,
                                         AmericanFootball = manager.AmericanFootball,
                                         Tennis = manager.Tennis,
                                         Football = manager.Football,
                                         Other = manager.Other,
                                         MixParlay = manager.MixParlay,
                                         Gamer = manager.Gamer,
                                         ChildrenCount = ctx.Managers.Where(m => m.Catagory == 5 && m.Majordomo.Equals(manager.Account)).Count()
                                     };

                        return result.ToList().Select(m => new Manager()
                        {
                            Id = m.Id,
                            Account = m.Account,
                            Title = m.Title,
                            ResidualCredit = m.ResidualCredit,
                            EnterAllow = m.EnterAllow,
                            Remark = m.Remark,
                            RemarkText = m.RemarkText,
                            AmericanBaseball = m.AmericanBaseball,
                            JapaneseBaseball = m.JapaneseBaseball,
                            TaiwaneseBaseball = m.TaiwaneseBaseball,
                            KoreanBaseball = m.TaiwaneseBaseball,
                            Hockey = m.Hockey,
                            Basketball = m.Basketball,
                            ColorBall = m.ColorBall,
                            AmericanFootball = m.AmericanFootball,
                            Tennis = m.Tennis,
                            Football = m.Football,
                            Other = m.Other,
                            MixParlay = m.MixParlay,
                            Gamer = m.Gamer,
                            ChildrenCount = m.ChildrenCount
                        }).ToList();
                        #endregion
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetMultiNames(ManagerCatagory catagory = ManagerCatagory.Majordomo)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    var result = from manager in ctx.Managers
                                 where manager.Catagory == (int)catagory
                                 orderby manager.Account.Length descending, manager.Account descending
                                 select manager.Account;
                    return result.Take(20).ToList<string>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Manager GetManagerByAccount(string account)
        {
            try
            {
                using (var ctx = new BaseDBContext())
                {
                    var query = from manager in ctx.Managers
                                where manager.Account.Equals(account, StringComparison.OrdinalIgnoreCase)
                                select manager;
                    return query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Manager> GetSubManagers(ManagerCatagory catagory, string searchStr)
        {
            try
            {
                try
                {
                    using (var ctx = new BaseDBContext())
                    {
                        var result = from manager in ctx.Managers
                                     where manager.Catagory == (int)catagory && manager.Account.Equals(searchStr)
                                     orderby manager.Account
                                     select new
                                     {
                                         Id = manager.Id,
                                         Account = manager.Account,
                                         Title = manager.Title,
                                         ResidualCredit = manager.ResidualCredit,
                                         EnterAllow = manager.EnterAllow,
                                         Remark = manager.Remark,
                                         RemarkText = manager.RemarkText,

                                         AmericanBaseball = manager.AmericanBaseball,
                                         JapaneseBaseball = manager.JapaneseBaseball,
                                         TaiwaneseBaseball = manager.TaiwaneseBaseball,
                                         KoreanBaseball = manager.KoreanBaseball,
                                         Hockey = manager.Hockey,
                                         Basketball = manager.Basketball,
                                         ColorBall = manager.ColorBall,
                                         AmericanFootball = manager.AmericanFootball,
                                         Tennis = manager.Tennis,
                                         Football = manager.Football,
                                         Other = manager.Other,
                                         MixParlay = manager.MixParlay,
                                         Gamer = manager.Gamer,
                                         ChildrenCount = ctx.Managers.Where(m => m.Catagory == (int)catagory + 1 && m.Majordomo.Equals(manager.Account)).Count()
                                     };

                        return result.ToList().Select(m => new Manager()
                        {
                            Id = m.Id,
                            Account = m.Account,
                            Title = m.Title,
                            ResidualCredit = m.ResidualCredit,
                            EnterAllow = m.EnterAllow,
                            Remark = m.Remark,
                            RemarkText = m.RemarkText,
                            AmericanBaseball = m.AmericanBaseball,
                            JapaneseBaseball = m.JapaneseBaseball,
                            TaiwaneseBaseball = m.TaiwaneseBaseball,
                            KoreanBaseball = m.TaiwaneseBaseball,
                            Hockey = m.Hockey,
                            Basketball = m.Basketball,
                            ColorBall = m.ColorBall,
                            AmericanFootball = m.AmericanFootball,
                            Tennis = m.Tennis,
                            Football = m.Football,
                            Other = m.Other,
                            MixParlay = m.MixParlay,
                            Gamer = m.Gamer,
                            ChildrenCount = m.ChildrenCount
                        }).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GetAllPermission(string searchUser)
        {
            return true;
        }
    }
}
