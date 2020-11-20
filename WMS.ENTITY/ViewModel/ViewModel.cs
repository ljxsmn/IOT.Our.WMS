using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.ENTITY.ViewModel
{
    public class ViewModel
    {
        //到货表
        public int Aid { get; set; }
        public string Acode { get; set; }               //编码
        public string Asuppler { get; set; }            //供应商  代号
        public int Agoodstype { get; set; }             //产品品类
        public int Atype { get; set; }                  //类型   1、原料，2、半成品，3、成品
        public DateTime Adate { get; set; }             //到货日期,
        public string Aman { get; set; }                //接获人 工号
        public int Astatus { get; set; }                //状态 1、待检查，2、已检查 3、未入库，4、部分入库，5、完成
        
        //到货详情

        public int Did { get; set; }
        public string Dabian { get; set; }              //到货编号 对应到货表编号
        public string Dgoods { get; set; }              //物品  编码
        public string Dspec { get; set; }               //计数规格  eg: 箱，个，袋
        public int Dnum { get; set; }                   //数量
        public decimal Dprice { get; set; }             //单位价值
        public string Dnote { get; set; }               //备注  

        //物品分类

        public int Tid { get; set; }
        public string Tname { get; set; }               //分类名称
        public int Tpid { get; set; }                   //父级分类

        //供应商
        public int Sid { get; set; }
        public string Sname { get; set; }               //供应商名称
        public string Stel { get; set; }                //  联系电话

        //员工表
        public int Eid { get; set; }
        public string Ecode { get; set; }               //员工工号
        public string Ename { get; set; }               //姓名
        public string Etel { get; set; }                //联系电话
        public int Erole { get; set; }                  //职位  对应权限

        //库区表
        public int Rid { get; set; }
        public string Rcode { get; set; }               //库区 编码  
        public string Rname { get; set; }               //库区 名称  eg:暂存区，商品去，报废区
        public string Rareawarm { get; set; }           //温区   eg: 常温，干杂区
        public string Rwh { get; set; }                 //所属仓库

        //添加类型
        public int ATId { get; set; }
        public string ATName { get; set; }              //类型名称

        //快捷到货
        public int WId { get; set; }                    //物料序号
        public string WBM { get; set; }                 //物料编码
        public string GS1 { get; set; }                 //GS1编码
        public string WName { get; set; }               //物料名称
        public string WSX { get; set; }                 //物料属性
        public string WGG { get; set; }                 //物料规格
        public string WDW { get; set; }                 //计量单位
        public string WSL { get; set; }                 //采购数量
        public decimal WLprice { get; set; }            //上次采购单价
        public decimal Wprice { get; set; }             //采购单价
        public decimal WJE { get; set; }                //金额
        public DateTime WDate { get; set; }             //生产时间
        public int WSJ { get; set; }                    //需求时间
        public string WContent { get; set; }            //备注
        public string WGYS { get; set; }                //供应商
        public string WKQ { get; set; }                 //卸货库区
        public DateTime WCDate { get; set; }            //采购日期

    }
}
