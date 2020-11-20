using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.ENTITY.ViewModel
{
    /// <summary>
    /// 角色菜单表  角色表  菜单表
    /// </summary>
    public class RolesMenusModel
    {
        //角色菜单表
        public int Rolemenu_id { get; set; }
        public int Rolemenu_roleid { get; set; }
        public int Rolemenu_menuid { get; set; }
        //角色表
        public int Rdid { get; set; }
        public string Roles_Name { get; set; }
        //菜单表
        public int Mdid { get; set; }
        public string MName { get; set; }
        public int Mid { get; set; }
    }
}
