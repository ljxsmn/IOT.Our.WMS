using HouseApi.Dal;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WMS.DAL.AllInterfaces;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;
namespace WMS.DAL.AllMethods
{
    public class RoleMangeDal:IRoleMangeDal
    {
        private SqlSugarClient db;
        public RoleMangeDal(IConfiguration config)
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = config.GetConnectionString("wmsdb"),
                DbType = SqlSugar.DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Register(Administrator model)
        {
            var p = Base64Helper.Base64Encode(model.Pwd);
            model.Pwd = p;
            int i = db.Insertable(model).ExecuteCommand();
            return i;
        }
       
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {
            Administrator model = new Administrator();
            string pwd1 = Base64Helper.Base64Encode(pwd);
            List<Administrator> lie = db.Queryable<Administrator>().Where(st => st.AName == name && st.Pwd == pwd1).ToList();
            return lie.Count;
        }
        /// <summary>
        /// 通过登录名获取角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Administratorrolecs> GetRoles(string name = "")
        {
            // var list = db.Queryable<Administrator, Roles, Administratorrole>((a, b, c) => new JoinQueryInfos(
            //  JoinType.Inner, a.Adid == b.Rdid,//可以用&&实现 on 条件 and
            //  JoinType.Inner, a.Adid == c.Admid
            //)).Where(a => a.AName == $"{name}").Select<Administratorrolecs>().ToList();
            // return list
            List<Administratorrolecs> list = db.Ado.SqlQuery<Administratorrolecs>($"select* from Administratorrole a inner join Administrator b on a.Adminid=b.Adid inner join Roles c on a.Rolerid = c.Rdid where b.AName= '{name}'");
            int i = 1;
            return list;
        }
        /// <summary>
        /// 通过角色来获取父级菜单
        /// </summary>
        /// <param name="rdid"></param>
        /// <returns></returns>
        public List<RolesMenusModel> GetMenu(int rdid)
        {
            List<RolesMenusModel> list = db.Ado.SqlQuery<RolesMenusModel>($"select * from Rolemenu a inner join Roles b on a.Rolemenu_id=b.Rdid inner join Menu c on a.Rolemenu_id=c.Mdid where b.Rdid='{rdid}'");
            int i= 1;
            return list;
        }
        /// <summary>
        /// 获取子级菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public List<Menu> ZiMenus(int id)
        {
            List<Menu> list = db.Ado.SqlQuery<Menu>($"select * from Menu where Mid='{id}'");
            int i = 1;
            return list;
        }

        /// <summary>
        /// 显示调拨表所有信息
        /// </summary>
        public List<EditModel> ShowAllo()
        {
            List<EditModel> list = db.Ado.SqlQuery<EditModel>($"select * from Allotedit a inner join Allottable b on a.Allotedit_iiid=b.Allottable_ID where b.iiiiiid=1");
            return list;
        }
        /// <summary>
        /// 绑定库区下拉
        /// </summary>
        /// <returns></returns>
        public List<Reservoir> ShowReser()
        {
            var getAll = db.Queryable<Reservoir>().ToList();//查询所有
            return getAll;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EditModel> ShowEdit(int id)
        {
            List<EditModel> list = db.Ado.SqlQuery<EditModel>($"select * from Allotedit  where Allotedit_iiid	='{id}'");
            return list;
        }
        /// <summary>
        /// 删除调拨表数据(假删)
        /// </summary>
        /// <returns></returns>
        public int DeleteReser(string id)
         {
             int i = db.Ado.ExecuteCommand($"update al set al.iiiiiid = 2 from Allottable al left join Allotedit adt on al.Allottable_ID =adt.Allotedit_iiid where al.Allottable_ID = {id}");
             return i;
         }

        /// <summary>
        /// 调拨表数据(关闭)
        /// </summary>
        /// <returns></returns>
        public int Guanbi(string id)
        {
            int i = db.Ado.ExecuteCommand($"update al set al.iiiiiid = 3 from Allottable al left join Allotedit adt on al.Allottable_ID =adt.Allotedit_iiid where al.Allottable_ID = {id}");
            return i;
        }
        /// <summary>
        /// 添加调拨表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddResert(Allottable model)
        {
            int i = db.Ado.ExecuteCommand($"insert into Allottable values('{model.Allottable_danhao}','{model.Allottable_diaochu}','{model.Allottable_diaoru}','{model.Allottable_people}','{model.Allottable_state}','{model.Allottable_Statess}','{model.Allottable_number}','{model.Allottable_ID}')");
            return i;
        }
        /// <summary>
        /// 添加调拨物品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public int AddAllotedit(Allotedit model)
        {
            int i = db.Ado.ExecuteCommand($"insert into Allotedit values('{model.Allotedit_iiid}','{model.Allotedit_bianma}','{model.Allotedit_name}','{model.Allotedit_kucun}','{model.Allotedit_number}','{model.Allotedit_shenpi}','{model.Allotedit_yichuku}','{model.Allotedit_zhouzhuank}','{model.Allotedit_danwei}','{model.Allotedit_danjia}','{model.Allotedit_image}')");
            return i;
        }
    }
}
