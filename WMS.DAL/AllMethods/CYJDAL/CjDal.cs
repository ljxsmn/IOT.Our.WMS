using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using WMS.DAL.AllInterfaces;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;

namespace WMS.DAL.AllMethods
{
    public class CjDal : ICjDal
    {
        private SqlSugarClient db;
        public CjDal()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=.;Initial Catalog=YLLCZC;Integrated Security=True",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
        /// <summary>
        /// 到货登记
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> DHDJ()
        {
            string sql = $"select * from ArriveGoods ag join Supplier sup on ag.Asuppler = sup.Sname " +
                $"join Emp e on ag.Aman = e.Ecode join GoodsType gt on ag.Agoodstype = gt.Tid";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }
        /// <summary>
        /// 到货记录
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> DHJL()
        {
            string sql = $"select* from ArriveGoods ag join ArriveDetail ad on ag.Acode = ad.Dabian " +
                 $"join Reservoir res on ad.DRcord = res.Rname join Goods g on ad.DGcode = g.Gcode " +
                 $"join AddType at on ag.ATyped=at.ATId";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }

        /// <summary>
        /// 到货登记详情（产品）
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> DHXQCP()
        {
            string sql = $"select* from ArriveGoods ag join ArriveDetail ad on ag.Acode = ad.Dabian " +
                 $"join Reservoir res on ad.DRcord = res.Rname join Goods g on ad.DGcode = g.Gcode " +
                 $"join AddType at on ag.ATyped=at.ATId where 1=1 and Atype=3 ";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }


        /// <summary>
        /// 到货登记详情（原料）
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> DHXQYL()
        {
            string sql = $"select* from ArriveGoods ag join ArriveDetail ad on ag.Acode = ad.Dabian " +
                 $"join Reservoir res on ad.DRcord = res.Rname join Goods g on ad.DGcode = g.Gcode " +
                 $"where 1=1 and Atype=1 ";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }


        /// <summary>
        /// 快捷到货
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> KJDH()
        {
            string sql = $"select * from KJDH k join Reservoir re on k.WKQ=re.Rcode " +
                $"join Supplier sup on k.WGYS = sup.Sname";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }


        /// <summary>
        /// 快捷到货详情
        /// </summary>
        /// <returns></returns>
        public ViewModel KJDJXQ(int ids)
        {
            string sql = $"select * from KJDH k join Reservoir re on k.WKQ=re.Rcode " +
                $"join Supplier sup on k.WGYS = sup.Sname where 1=1 and WId={ids}";
            return db.Ado.SqlQuery<ViewModel>(sql)[0];
        }


        /// <summary>
        /// 快捷到货编辑
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public int UPdete(ViewModel vm)
        {
            string sql = $"update k set k.WSL='{vm.WSL}',k.Wprice ='{vm.Wprice}," +
                $"k.Wje='{vm.WJE}',k.WDate='{vm.WDate},k.WSJ='{vm.WSJ},k.WContent='{vm.WContent}'," +
                $"k.WGYS='{vm.WGYS}',k.WKQ='{vm.WKQ}',k.WCDate='{vm.WCDate}'" +
                $"from KJDH k join Reservoir re on k.WKQ=" +
                $"re.Rcodejoin Supplier sup on k.WGYS = sup.Sname";
            return db.Ado.ExecuteCommand(sql);
        }


        /// <summary>
        /// 快捷到货反填
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ViewModel FanT(int ids)
        {
            string sql = $"select * from KJDH  where WId={ids}";
            return db.Ado.SqlQuery<ViewModel>(sql)[0];
        }


        /// <summary>
        /// 快捷到货详情
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ViewModel KJXQ(int ids)
        {
            string sql = $"select * from KJDH  where WId={ids}";
            return db.Ado.SqlQuery<ViewModel>(sql)[0];
        }

        /// <summary>
        /// 绑定供货商
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> BangGYS()
        {
            string sql = $"select * from Supplier";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }
        /// <summary>
        /// 绑定产品品类
        /// </summary>
        /// <returns></returns>
        public List<ViewModel> BangPL()
        {
            string sql = $"select * from GoodsType";
            return db.Ado.SqlQuery<ViewModel>(sql);
        }
    }
}