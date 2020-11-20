using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.ENTITY.ViewModel
{
    /// <summary>
    /// 管理员表  角色表   管理员角色表
    /// </summary>
    public class Administratorrolecs
    {
            public int Adid { get; set; }  //ID
            public string AName { get; set; }//姓名
            public string Pwd { get; set; }//密码
            public int Rdid { get; set; }  //ID
            public string Roles_Name { get; set; }//角色名称
            [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
            public int Admid { get; set; }  //ID
            public int Adminid { get; set; }//姓名
            public int Rolerid { get; set; }//密码
    }
}
