﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlyingSnow.Database
{
    using Contract.Base;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class BaseDBContext : DbContext
    {
        public BaseDBContext()
            : base("name=BaseEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<t_member> t_member { get; set; }
        public virtual DbSet<Alliance> Alliances { get; set; }
        public virtual DbSet<BallCountry> BallCountries { get; set; }
    }
}
