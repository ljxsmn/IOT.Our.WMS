using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.DAL.AllInterfaces;
using WMS.DAL.AllMethods;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;

namespace WMS.UI.API
{

    /// <summary>
    /// 到货管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChenYJController : ControllerBase
    {
        private ICjDal _jdal;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="cjDal"></param>
        public ChenYJController(ICjDal cjDal)
        {
            _jdal = cjDal;
        }

        /// <summary>
        /// 到货登记
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DHDJ(int PageIndex = 1, int PageSize = 10,string BH="", string PL = "", string GYS = "", int State=0, string Peo = "")
        {
            List<ViewModel> list = _jdal.DHDJ();
            list = list.Where(p => p.Acode.Contains(BH)).ToList();
            list = list.Where(p => p.Tname.Contains(PL)).ToList();
            list = list.Where(p => p.Asuppler.Contains(GYS)).ToList();
            list = list.Where(p => p.Astatus==State).ToList();
            list = list.Where(p => p.Ename.Contains(Peo)).ToList();
            //分页
            int count = list.Count;
            list = list.Skip((PageIndex - 1) * 10).Take(10).ToList();
            return Ok(list);
        }

        /// <summary>
        /// 到货记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DHJL(int PageIndex = 1,int PageSize=10 )
        {
            List<ViewModel> list = _jdal.DHJL();
            int count = list.Count;
            list = list.Skip((PageIndex - 1) * 10).Take(10).ToList();
            return Ok(list);
        }

        /// <summary>
        /// 到货登记详情（产品）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DHXQCP()
        {
            List<ViewModel> list = _jdal.DHXQCP();
            return Ok(list);
        }
        /// <summary>
        /// 到货登记详情（原料）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DHXQYL()
        {
            List<ViewModel> list = _jdal.DHXQYL();
            return Ok(list);
        }
        /// <summary>
        /// 快捷到货
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult KJDH()
        {
            List<ViewModel> list = _jdal.KJDH();
            return Ok(list);
        }
        /// <summary>
        /// 快捷到货详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult KJDJXQ(int ids)
        {
            ViewModel list = _jdal.KJDJXQ(ids);
            return Ok(list);
        }
        /// <summary>
        /// 快捷到货编辑
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UPdete(ViewModel vm)
        {
            int a = _jdal.UPdete(vm);
            return Ok(a);
        }
        /// <summary>
        /// 快捷到货反填
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FanT(int ids)
        {
            ViewModel list = _jdal.FanT(ids);
            return Ok(list);
        }
        /// <summary>
        /// 快捷到货详情
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult KJXQ(int ids)
        {
            ViewModel list = _jdal.KJXQ(ids);
            return Ok(list);
        }

        /// <summary>
        /// 绑定供货商
        /// </summary>
        /// <returns></returns>
         [HttpGet]
        public IActionResult BangGYS()
        {
            List<ViewModel> list = _jdal.BangGYS();
            return Ok(list);
        }
        /// <summary>
        /// 绑定产品品类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BangPL()
        {
            List<ViewModel> list = _jdal.BangPL();
            return Ok(list);
        }
    }
}
