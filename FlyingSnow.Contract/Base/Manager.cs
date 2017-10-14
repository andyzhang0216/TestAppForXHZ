using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract.Base
{
    public partial class Manager
    {
        /// <summary>
        /// Key
        /// </summary>
        public decimal Id { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public Nullable<int> Catagory { get; set; }
        /// <summary>
        /// EnterAllowed
        /// </summary>
        public Nullable<int> EnterAllow { get; set; }
        /// <summary>
        /// 错误备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 错误
        /// </summary>
        public Nullable<int> Error { get; set; }
        /// <summary>
        /// 总监
        /// </summary>
        public string Majordomo { get; set; }
        /// <summary>
        /// 大股东
        /// </summary>
        public string BigPartner { get; set; }
        /// <summary>
        /// 股东
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// 总代理
        /// </summary>
        public string GeneralAgency { get; set; }
        /// <summary>
        /// 代理
        /// </summary>
        public string Agency { get; set; }
        /// <summary>
        /// 运动信用额度
        /// </summary>
        public Nullable<double> Credit { get; set; }
        /// <summary>
        /// 运动剩余额度
        /// </summary>
        public Nullable<double> ResidualCredit { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public string Percent { get; set; }
        public string SignInIP { get; set; }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public Nullable<System.DateTime> LastSignInTime { get; set; }
        /// <summary>
        /// 足球f_zq
        /// </summary>
        public Nullable<double> Football { get; set; }
        /// <summary>
        /// 篮球f_lq
        /// </summary>
        public Nullable<double> Basketball { get; set; }
        /// <summary>
        /// 美式足球
        /// </summary>
        public Nullable<double> AmericanFootball { get; set; }
        /// <summary>
        /// 美棒
        /// </summary>
        public Nullable<double> AmericanBaseball { get; set; }
        /// <summary>
        /// 日棒
        /// </summary>
        public Nullable<double> JapaneseBaseball { get; set; }
        /// <summary>
        /// 韩棒f_hb
        /// </summary>
        public Nullable<double> KoreanBaseball { get; set; }
        /// <summary>
        /// 台棒f_bb
        /// </summary>
        public Nullable<double> TaiwaneseBaseball { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public Nullable<decimal> Sx { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public Nullable<int> Hygl { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public Nullable<int> Glhy { get; set; }
        /// <summary>
        /// 停压项目 f_ddsx
        /// </summary>
        public Nullable<double> LimitCatagory { get; set; }
        /// <summary>
        /// 注册时间f_joindate
        /// </summary>
        public Nullable<System.DateTime> SignUpTime { get; set; }
        /// <summary>
        /// 延迟开关
        /// </summary>
        public Nullable<int> Defer { get; set; }
        /// <summary>
        /// 指数f_zs
        /// </summary>
        public Nullable<double> Exponent { get; set; }
        /// <summary>
        /// 修改时间f_xgtime
        /// </summary>
        public Nullable<System.DateTime> ModifyTime { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string Modifier { get; set; }
        /// <summary>
        /// 赛马f_sm
        /// </summary>
        public Nullable<double> HorseRace2 { get; set; }
        /// <summary>
        /// 赛马f_ss
        /// </summary>
        public Nullable<double> HorseRace { get; set; }
        /// <summary>
        /// 对战f_game
        /// </summary>
        public Nullable<double> VSGame { get; set; }
        /// <summary>
        /// 游戏信用额度
        /// </summary>
        public Nullable<double> GameCredit { get; set; }
        /// <summary>
        /// 游戏剩余额度
        /// </summary>
        public Nullable<double> GameSurplus { get; set; }
        /// <summary>
        /// 网球f_wq
        /// </summary>
        public Nullable<double> Tennis { get; set; }
        /// <summary>
        /// 冰球f_bq
        /// </summary>
        public Nullable<double> Hockey { get; set; }
        /// <summary>
        /// 彩球f_cq
        /// </summary>
        public Nullable<double> ColorBall { get; set; }
        /// <summary>
        /// 游戏总输上限
        /// </summary>
        public Nullable<double> GameLoseLimit { get; set; }
        /// <summary>
        /// 记录报表查询员可查询总监f_MajAcc 
        /// </summary>
        public string SearchableMajordomo { get; set; }
        /// <summary>
        /// 真人f_Vd
        /// </summary>
        public Nullable<double> Gamer { get; set; }
        /// <summary>
        /// 真人信用额度f_VdCredit 
        /// </summary>
        public Nullable<double> GamerCredit { get; set; }
        /// <summary>
        /// 真人剩余额度f_VdSurplus 
        /// </summary>
        public Nullable<double> GamerSurplus { get; set; }
        /// <summary>
        /// 真人总输上限f_Vdzssx 
        /// </summary>
        public Nullable<double> GamerLoseLimit { get; set; }
        /// <summary>
        /// 电子f_Et
        /// </summary>
        public Nullable<double> ComputerGame { get; set; }
        /// <summary>
        /// 电子信用额度f_etCredit  
        /// </summary>
        public Nullable<double> ComputerGameCredit { get; set; }
        /// <summary>
        /// 电子剩余额度f_etSurplus 
        /// </summary>
        public Nullable<double> ComputerGameSurplus { get; set; }
        /// <summary>
        /// 首次登录是否需要重新设定新密码f_pdpass
        /// </summary>
        public Nullable<byte> ResetPasswordFlag { get; set; }
        /// <summary>
        /// 其他f_ot
        /// </summary>
        public Nullable<double> Other { get; set; }
        /// <summary>
        /// 备注f_RemarkText
        /// </summary>
        public string RemarkText { get; set; }
        /// <summary>
        /// 综合过关f_zh
        /// </summary>
        public Nullable<double> MixParlay { get; set; }
        /// <summary>
        /// 汇款方式f_BankCode
        /// </summary>
        public string PaymentMethod { get; set; }
        /// <summary>
        /// 汇款帐号
        /// </summary>
        public string RemittanceAccount { get; set; }
        /// <summary>
        /// 汇款帐号
        /// </summary>
        public string RemittanceName { get; set; }
        /// <summary>
        /// un        
        /// /// </summary>
        public Nullable<double> Deposit { get; set; }
        /// <summary>
        /// 安全性问题 
        /// </summary>
        public string SecurityProblem { get; set; }
        /// <summary>
        /// 安全性答案
        /// </summary>
        public string SecurityAnswer { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public Nullable<byte> PhotoState { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public Nullable<byte> IsBankShow { get; set; }
        /// <summary>
        /// email验证 
        /// </summary>
        public Nullable<byte> EmailState { get; set; }
        /// <summary>
        /// email验证码f_newID
        /// </summary>
        public string EmailVerificationCode { get; set; }
        /// <summary>
        /// 银行分支行f_SubBank
        /// </summary>
        public string SubBank { get; set; }
        /// <summary>
        /// 組別f_group
        /// </summary>
        public Nullable<byte> Group { get; set; }
        /// <summary>
        /// un
        /// </summary>
        public string FirstGener { get; set; }
        public string SecondGener { get; set; }
        public string ThirdGener { get; set; }
        public Nullable<int> Looknode { get; set; }
        /// <summary>
        /// 平台设置开关
        /// </summary>
        public Nullable<int> PlatState { get; set; }
        /// <summary>
        /// 五级端客户关系管理是否开启（0为关闭，1为开启）   
        /// </summary>
        public Nullable<byte> ClientStatus { get; set; }
        /// <summary>
        /// 经销商是否允许加入会员,0-否，1-是 f_isJoinMem 
        /// </summary>
        public Nullable<byte> AllowJoinMember { get; set; }
        /// <summary>
        /// 身分證 f_idCard
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 五级帐号是否开放新增会员,0-关闭，1-开放 f_isOpenMem
        /// </summary>
        public Nullable<byte> AllowAddMember { get; set; }
        /// <summary>
        /// 用户状态 0为正常户，1为停权户 f_ishow 
        /// </summary>
        public Nullable<double> Status { get; set; }
        public Nullable<byte> VerifyCount { get; set; }
        public Nullable<int> VirtualDeposit { get; set; }
        public Nullable<byte> ExcelNum { get; set; }
        /// <summary>
        /// 分站（二进制） f_webSite
        /// </summary>
        public Nullable<int> SubSite { get; set; }
        /// <summary>
        /// 短信验证
        /// </summary>
        public string PhoneAuth { get; set; }
        /// <summary>
        /// 短信验证时间
        /// </summary>
        public Nullable<System.DateTime> PhoneAuthDate { get; set; }
        /// <summary>
        /// 验证方式f_yzMode
        /// </summary>
        public Nullable<byte> VerifyMethod { get; set; }
        /// <summary>
        /// 部门 f_dept
        /// </summary>
        public string Department { get; set; }
        public string RemarkPyatyi { get; set; }
        public string Remark3 { get; set; }
    }

    public partial class Manager
    {
        public int ChildrenCount { get; set; }
    }

    public enum ManagerCatagory : int
    {
        Majordomo = 4,
        BigPartner = 5,
        Partner = 6,
        GeneralAgency = 7,
        Agency = 8,
        Member = 9,
        SubMajordomo = 44,
        SubBigPartner = 55,
        SubPartner = 66,
        SubGeneralAgency = 77,
        SubAgency = 88
    }
}
