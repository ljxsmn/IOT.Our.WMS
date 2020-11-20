using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WMS.DAL.AllInterfaces;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;

namespace WMS.UI.API
{
    /// <summary>
    /// 用户管理模块
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleMangeDal _dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dal"></param>
        public RoleController(IRoleMangeDal dal)
        {
            _dal = dal;
        }
        /// <summary>
        /// 管理员加密注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int Register(string model)
        {
            Administrator model1 = JsonConvert.DeserializeObject<Administrator>(model);
            return _dal.Register(model1);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        [HttpGet]
        public int Login(string name, string pwd)
        {
            return _dal.Login(name, pwd);
        }
        /// <summary>
        /// 根据登录名获取角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Administratorrolecs> GetRoles(string name = "")
        {
            List<Administratorrolecs> list = _dal.GetRoles(name);
            return list;
        }
        /// <summary>
        /// 通过角色来获取父级菜单
        /// </summary>
        /// <param name="rdid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<RolesMenusModel> GetMenu(int rdid)
        {
            List<RolesMenusModel> list = _dal.GetMenu(rdid);
            //int i =1;
            return list;
        }
        /// <summary>
        /// 获取子级菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Menu> ZiMenus(int id)
        {
            return _dal.ZiMenus(id);
        }

        /// <summary>
        /// 显示调拨表所有信息
        /// </summary>
        [HttpGet]
        public List<EditModel> ShowAllo(int index = 0, int size = 4, int diaochuid = 0, int diaoruid = 0, string goodsbianma = "", string goodsname = "", int stateid = 0, string diaobodanhao = "")
        {
            List<EditModel> list = _dal.ShowAllo();
            //调出
            if (diaochuid != 0)
            {
                list = list.Where(x => x.Allottable_diaochu == diaochuid).ToList();
            }
            //调入
            if (diaoruid != 0)
            {
                list = list.Where(x => x.Allottable_diaoru == diaoruid).ToList();
            }
            //商品编码
            if (!string.IsNullOrEmpty(goodsbianma))
            {
                list = list.Where(x => x.Allotedit_bianma.Contains(goodsbianma)).ToList();
            }
            //商品名称
            if (!string.IsNullOrEmpty(goodsname))
            {
                list = list.Where(x => x.Allotedit_name.Contains(goodsname)).ToList();
            }
            //审批状态
            if (stateid != 0)
            {
                list = list.Where(x => x.Allottable_state == stateid).ToList();
            }
            //调拨单号
            if (!string.IsNullOrEmpty(diaobodanhao))
            {
                list = list.Where(x => x.Allottable_danhao.Contains(diaobodanhao)).ToList();
            }
            //分页
            int count = list.Count;
            list = list.Skip((index - 1) * 4).Take(4).ToList();
            return list;
        }


        /// <summary>
        /// 绑定库区下拉
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Reservoir> ShowReser()
        {
            return _dal.ShowReser();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<EditModel> ShowEdit(int id)
        {
            return _dal.ShowEdit(id);
        }
        /// <summary>
        /// 删除调拨表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeleteReser(string id)
        {
            return _dal.DeleteReser(id);
        }
        /// <summary>
        /// 调拨表数据(关闭)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int Guanbi(string id)
        {
            return _dal.Guanbi(id);
        }
        /// <summary>
        /// 添加调拨表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddResert(string model)
        {
            Allottable model1 = JsonConvert.DeserializeObject<Allottable>(model);
            return _dal.AddResert(model1);
        }
        /// <summary>
        /// 添加调拨物品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddAllotedit(string model)
        {
            Allotedit model1 = JsonConvert.DeserializeObject<Allotedit>(model);
            return _dal.AddAllotedit(model1);
        }
    }
}