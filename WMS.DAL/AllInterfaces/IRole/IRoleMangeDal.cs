using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;

namespace WMS.DAL.AllInterfaces
{
    public interface IRoleMangeDal
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Register(Administrator model);
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public int Login(string name,string pwd);
        /// <summary>
        /// 通过登录名称获取角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Administratorrolecs> GetRoles(string name = "");
        /// <summary>
        /// 通过角色来获取父级菜单
        /// </summary>
        /// <param name="rdid"></param>
        /// <returns></returns>
        public List<RolesMenusModel> GetMenu(int rdid);
        /// <summary>
        /// 获取子级菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public List<Menu> ZiMenus(int id);
        /// <summary>
        /// 显示调拨表所有信息
        /// </summary>
        /// <returns></returns>
        public List<EditModel> ShowAllo();


        /// <summary>
        /// 显示库区所有信息
        /// </summary>
        /// <returns></returns>
        public List<Reservoir> ShowReser();

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EditModel> ShowEdit(int id);
        /// <summary>
        /// 删除调拨表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteReser(string id);
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Guanbi(string id);
        /// <summary>
        /// 添加调拨表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddResert(Allottable model);
        /// <summary>
        /// 添加物品详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddAllotedit(Allotedit model);

    }
}
