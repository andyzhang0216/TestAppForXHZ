using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Bill
{
    public partial class Bill
    {
        public decimal ID { get; set; }
        /// <summary>
        /// 账务日期 f_date
        /// </summary>
        public Nullable<System.DateTime> TransferDate { get; set; }
        /// <summary>
        /// 下注时间 f_time
        /// </summary>
        public Nullable<System.DateTime> BetTime { get; set; }
        /// <summary>
        /// 注单编号 f_id
        /// </summary>
        public Nullable<decimal> BillId { get; set; }
        /// <summary>
        /// 比赛类型 f_typ 
        /// Parlay: f_typ1
        /// </summary>
        public string GameType { get; set; }
        // 下注方式 f_type
        public string BetType { get; set; }
        // 场次类型 f_scene 0 全场 1 上半场 2 下半场 8 多种玩法 11 第一节 12 第二节 13 第三节 14 第四节 真人游戏百家乐中该字段表示连赢关数 255表示“和局” 
        public byte? SceneCatagory { get; set; }
        /// 下注内容 f_content
        public string BetContent { get; set; }
        /// 赔率 f_pl
        public Nullable<double> Odds { get; set; }
        /// <summary>
        /// Parlay:总金额 f_money
        /// </summary>
        public Nullable<double> BetMoney { get; set; }
        /// <summary>
        /// Base:结果 f_result
        /// Parlay:退佣设定 
        /// </summary>
        public Nullable<double> Result { get; set; }
        /// <summary>
        /// 退佣金额 f_ty
        /// </summary>
        public Nullable<double> RefundAmount { get; set; }
        /// <summary>
        /// Base:会员结果 f_mresult
        /// Parlay:结果
        /// </summary>
        public Nullable<double> MemberResult { get; set; }
        /// <summary>
        /// f_member
        /// </summary>
        public string Member { get; set; }
        /// f_team 玩法
        public string PlayingMethod { get; set; }
        // f_gameid
        public Nullable<decimal> GameId { get; set; }
        /// <summary>
        /// 可赢金额 f_yssy
        /// </summary>
        public Nullable<double> WinAmount { get; set; }
        /// <summary>
        /// Base：f_js 结算 状态0：未计算1：已计算 2：取消 3：未打满九局 4：待定中 f_js
        /// Parlay： 判断比赛结果是否是-1如果是不进行计算，js=2计算 编辑 
        /// </summary>
        public Nullable<byte> CalculateStatus { get; set; }
        /// <summary>
        /// 危险等级 f_peril
        /// </summary>
        public Nullable<byte> MemberDangerLevel { get; set; }
        // 联盟 f_alliance
        public string Alliance { get; set; }

        public string Majordomo { get; set; }
        public string BigPartner { get; set; }
        public string Partner { get; set; }
        public string GeneralAgency { get; set; }
        public string Agency { get; set; }
        /// <summary>
        /// Base:总监有效投注 f_mo0
        /// Parlay:總監結果 
        /// </summary>
        public Nullable<double> EffectiveBetOfMajordomo { get; set; }
        public Nullable<double> EffectiveBetOfBigPartner { get; set; }
        public Nullable<double> EffectiveBetOfPartner { get; set; }
        public Nullable<double> EffectiveBetOfGeneralAgency { get; set; }
        public Nullable<double> EffectiveBetOfAgency { get; set; }
        /// <summary>
        /// Base: 会员结果 
        /// Parlay:代理商未拆帳 f_mo5
        /// </summary>
        public Nullable<double> EffectiveBetOfMember { get; set; }
        /// 赔率基准 f_rrf0
        public Nullable<double> OddsStandard { get; set; }
        /// 符号（值为“0-3”对应：平、+、-、输） f_rrf1  
        public Nullable<double> OddsFlag { get; set; }
        /// 百分比  f_rrf2  
        public Nullable<double> OddsPercent { get; set; }
        /// f_rrf3
        public Nullable<int> SpreadFlag { get; set; }
        /// f_ddx0
        public Nullable<double> Score { get; set; }
        /// f_ddx1
        public Nullable<double> ScoreFlag { get; set; }
        /// f_ddx2
        public Nullable<double> ScorePercent { get; set; }
        /// <summary>
        /// f_del
        /// </summary>
        public Nullable<byte> Status { get; set; }
        /// <summary>
        /// 会员反水 f_ty0
        /// </summary>
        public Nullable<double> RefundMember { get; set; }
        /// <summary>
        /// 大股东反水 f_ty01
        /// </summary>
        public Nullable<double> RefundBigPartner { get; set; }
        /// <summary>
        /// 股东反水 f_ty02
        /// </summary>
        public Nullable<double> RefundPartner { get; set; }
        /// <summary>
        /// 总代理反水 f_ty03
        /// </summary>
        public Nullable<double> RefundGeneralAgency { get; set; }
        /// <summary>
        /// 代理反水 f_ty04
        /// </summary>
        public Nullable<double> RefundAgency { get; set; }
        /// <summary>
        /// 总监反水 f_ty00
        /// </summary>
        public Nullable<double> RefundMajordomo { get; set; }
        /// <summary>
        /// f_ip
        /// </summary>
        public string BillIP { get; set; }
        /// <summary>
        /// 总公司结果 f_mo
        /// </summary>
        public Nullable<double> CompanyResult { get; set; }
        // 左队让分 f_rzjzf
        public Nullable<double> ReferPointLeft { get; set; }
        // f_ryjzf
        public Nullable<double> ReferPointRight { get; set; }
        public Nullable<int> ReferPointFlag { get; set; }
        public Nullable<double> f_demo { get; set; }
        /// <summary>
        /// 总监占成（拆账） f_cc
        /// </summary>
        public Nullable<double> OccupyByMajordomo { get; set; }
        public Nullable<double> OccupyByBigPartner { get; set; }
        public Nullable<double> OccupyByPartner { get; set; }
        public Nullable<double> OccupyByGeneralAgency { get; set; }
        public Nullable<double> OccupyByAgency { get; set; }
        // f_WatchTime
        public Nullable<System.DateTime> f_WatchTime { get; set; }
        // f_PublicPoint
        public Nullable<double> PublicPoint { get; set; }
        // f_dyxs
        public Nullable<byte> GameStatus { get; set; }
        /// <summary>
        /// f_AuthCode
        /// </summary>
        public string AuthCode { get; set; }
        // f_bzflag
        public Nullable<byte> RemarkFlag { get; set; }
        /// <summary>
        /// 剩余金额
        /// </summary>
        public Nullable<double> SurplusMoney { get; set; }
        // f_mlevel
        public Nullable<int> f_mlevel { get; set; }
        // 下注延迟秒数 f_waittime
        public Nullable<byte> BetDelaySecond { get; set; }
        public Nullable<byte> DeleteDelaySecond { get; set; }
        // f_show
        public Nullable<byte> AffirmState { get; set; }
        /// <summary>
        /// f_way
        /// </summary>
        public Nullable<byte> BetFlag { get; set; }
        // f_manager
        public string Manager { get; set; }
        // f_mgroup
        public Nullable<byte> ManagerGroup { get; set; }
        /// <summary>
        /// f_exflag
        /// </summary>
        public Nullable<byte> ExFlag { get; set; }
        /// <summary>
        /// f_area
        /// </summary>
        public string IPArea { get; set; }
        // f_UpWaitName
        public string UpWaitName { get; set; }
        /// <summary>
        /// f_jscount
        /// </summary>
        public Nullable<byte> CalculateCount { get; set; }
        /// <summary>
        /// f_ischange
        /// </summary>
        public Nullable<byte> f_ischange { get; set; }
        /// <summary>
        /// f_DCinfoID
        /// </summary>
        public Nullable<int> f_DCinfoID { get; set; }
    }

    public class QueryObject
    {
        public DateTime? TransferDate { get; set; }
        public DateTime[] BetTimes { get; set; }
        public GameTypes? GameType { get; set; }
        public CalculateStatus? CalculateStatus { get; set; }
        public BetType? BetType { get; set; }
        public BillCatagorys? BillCatagory { get; set; }
        public QueryConditions? QueryCondition { get; set; }

        public string Member { get; set; }
        public string Agency { get; set; }
        public string GeneralAgency { get; set; }
        public string Majordomo { get; set; }
        public string BigPartner { get; set; }
        public string Partner { get; set; }
        public decimal BillId { get; set; }
        public string BillIP { get; set; }
        public string GameNumber { get; set; }
    }

    public enum QueryConditions
    {
        Member,
        Agency,
        GeneralAgency,
        Partner,
        BigPartner,
        Majordomo,
        BillId,
        BillIP,
        GameNumber
    }

    public enum BillCatagorys
    {
        Available = 0,
        Deleted = 1,//所有删除注单
        GoalCanceled = 2,//进球单取消注单
        ArbitrageCanceled = 3,//套利取消注单
        OrganizationBetCanceled = 4,//团体下注取消注单
        ExceptionCanceled = 5,//异常取消注单
        AllDeleteCanceled = 6,//所有删除取消注单
        Danger = 7,
        [EnumValue("1")]
        AddWaterArbitrage = 8,//与打水套利同步注单
        [EnumValue("2")]
        WashOwnedArbitrage = 9,//与洗成数套利同步注单
        [EnumValue("3")]
        OrganizationBet = 10,//与团体下注同步注单
        [EnumValue("4")]
        BorrowArbitrage = 11,//与打洞套利同步注单
        AllRemarked = 12,
        [EnumValue("6")]
        RefuseBet = 13,//拒绝投注注单
        [EnumValue("7")]
        RedCardCancel = 14,//红卡取消注单
        AllCanceled = 15,//所有取消注单是指：进球单取消注单、套利取消注单、团体下注取消注单、异常取消注单、投注拒绝注单、红卡取消注单
        [EnumValue("16")]
        BeforeOpen = 16,//早盘注单
        [EnumValue("17")]
        BeforeClose = 17,//收盘前注单
        [EnumValue("18")]
        HighChange = 18,//高点反下注单

        GeneralMember = 24,//只显示正常会员注单
        UnusualIP = 25,//只显示异常IP注单
        BetConfirm = 26,//只显投注确认注单
        Demotion = 27,//降星
        Remarked = 28,//只显有删除备注的注单
    }

    public enum CalculateStatus : int
    {
        NotCalcuate = 0,
        OnlyCalcuted = 1,
        Cancel = 2,
        NotComplete = 3,
        Waitting = 4,
        Calcuted
    }

    public enum GameTypes
    {
        All,
        [EnumValue("b_zq")]
        Football,
        [EnumValue("b_lq")]
        Basketball,
        [EnumValue("b_mz")]
        AmericanFootball,
        [EnumValue("b_bj")]
        AmericanBaseball,
        [EnumValue("b_by")]
        JapaneseBaseball,
        [EnumValue("b_bb")]
        TaiwaneseBaseball,
        [EnumValue("b_hb")]
        KoreanBaseball,
        [EnumValue("b_wq")]
        Tennis,
        [EnumValue("b_bq")]
        IceHockey,
        [EnumValue("b_cq")]
        ColorBall,
        [EnumValue("b_ss")]
        HorseRace,
        [EnumValue("b_sm")]
        HorseRace2,
        [EnumValue("b_ot")]
        Other,
        [EnumValue("b_vd")]
        Gamer,
        [EnumValue("b_dz")]
        VSGame
    }


    public enum BetType
    {
        All,
        [EnumValue("l_rf")]
        Spread,//让分
        [EnumValue("l_dx")]
        Score,//大小
        [EnumValue("l_dy")]
        Capot,//独赢
        [EnumValue("l_ds")]
        SingleOrDouble,//单双
        [EnumValue("l_qsf")]
        VieFirstPoint,//抢首分
        [EnumValue("l_qwf")]
        VieLastPoint,//抢尾分
        [EnumValue("l_djzgdf")]
        HighScoreInSection,//单节最高得分
        [EnumValue("l_tbtz")]
        SpecialBet,//特别投注
        [EnumValue("l_td15fz")]
        Designated15Mins,//特定15分钟
        [EnumValue("l_rqs")]
        Goals,//入球数
        [EnumValue("l_bd")]
        WaveBravery,//波胆
        [EnumValue("l_bqc")]
        HalfOrFull,//半全场
        [EnumValue("l_zdrf")]
        BallingSpread,//滚球让分
        [EnumValue("l_zddx")]
        BallingScore,
        [EnumValue("l_zddy")]
        BallingCapot,
        [EnumValue("l_zdds")]
        BallingSingleOrDouble,
        [EnumValue("l_zdrqs")]
        BallingGoals,
        [EnumValue("l_zdbd")]
        BallingWaveBravery,
        [EnumValue("l_zdbqc")]
        BallingHalfOrFull,
        [EnumValue("l_ye")]
        OneLoseTwoWin,//一输二赢
        [EnumValue("l_gg")]
        Parlay,//过关
        [EnumValue("l_zhgg")]
        MixParlay,//综合过关

        [EnumValue("l_game_VD")]
        GamerAll,//所有真人
                 //l_game_SD
                 //l_game_LH
                 //l_game_MPBJL
                 //l_game_EBG
                 //l_game_TB
                 //l_game_XFTB
                 //l_game_LP
                 //l_game_SG
                 //l_game_NN
                 //l_game_21D
                 //l_game_ZRPJ
                 //l_game_ZRLH
                 //l_game_ZRDZPK
                 //l_game_FT
                 //l_game_XFBJL
                 //l_game_YXX
                 //l_game_ALL
    }
}
