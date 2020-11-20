using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.ENTITY.InitialTable
{

    //仓库
    [SugarTable("WareHouse")]
    public class WareHouse
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Wid { get; set; }
        public string Wcode { get; set; }       //编码
        public string Wname { get; set; }       //名称
        public string Waddress { get; set; }    //地址
        public int Wstatus { get; set; }        //状态  eg:启用 禁用
    }

    //库区
    [SugarTable("Reservoir")]
    public class Reservoir
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Rid { get; set; }
        public string Rcode { get; set; }  //库区 编码  
        public string Rname { get; set; }  //库区 名称  eg:暂存区，商品去，报废区
        public string Rareawarm { get; set; }  //温区   eg: 常温，干杂区
        public string Rwh { get; set; }  //所属仓库
    }


    //物品
    [SugarTable("Goods")]
    public class Goods
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Gid { get; set; }
        public string Gcode { get; set; }       // 编号
        public string Gname { get; set; }       // 名称
        public string Gspec { get; set; }       //规格  eg: 500ml/瓶 ，7公分果径..
        public int Gtype { get; set; }       // 分类
    }

    //物品分类
    [SugarTable("GoodsType")]
    public class GoodsType
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Tid { get; set; }
        public string Tname { get; set; }  //分类名称
        public int Tpid { get; set; }  //父级分类
    }

    //供应商信息
    [SugarTable("Supplier")]
    public class Supplier
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Sid { get; set; }
        public string Sname { get; set; }  //供应商名称
        public string Stel { get; set; }  //  联系电话
    }

    //公司员工
    [SugarTable("Emp")]
    public class Emp
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Eid { get; set; }
        public string Ecode { get; set; }  //员工工号
        public string Ename { get; set; }  //姓名
        public string Etel { get; set; }  //联系电话
        public int Erole { get; set; }  //   职位  对应权限
    }

    //到货表  报告表
    [SugarTable("ArriveGoods")]
    public class ArriveGoods
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Aid { get; set; }
        public string Acode { get; set; }  //编码
        public string Asuppler { get; set; }  //供应商  代号
        public int Agoodstype { get; set; }  //产品品类
        public int Atype { get; set; }  //类型   1、原料，2、半成品，3、成品
        public DateTime Adate { get; set; }  //到货日期,
        public string Aman { get; set; }  //接获人 工号
        public int Astatus { get; set; }  //          状态 1、待检查，2、已检查 3、未入库，4、部分入库，5、完成
    }

    //到货详情
    [SugarTable("ArriveDetail")]
    public class ArriveDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Did { get; set; }
        public string Dabian { get; set; }  //到货编号 对应到货表编号
        public string Dgoods { get; set; }  //物品  编码
        public string Dspec { get; set; }  //计数规格  eg: 箱，个，袋
        public int Dnum { get; set; }  //数量
        public int DGode { get; set; }//物料编码
        public decimal Dprice { get; set; }  //单位价值
        public string Dnote { get; set; }  //     备注          

    }

    //库存表  (仓库已有的物品)
    [SugarTable("Priorities")]
    public class Priorities
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Pid { get; set; }
        public string Pgoodse { get; set; }  //物品  编码
        public string Pspec { get; set; }  //   计数规格  eg: 箱，个，袋
        public int Pnum { get; set; }  //     拥有数量
        public decimal Pprice { get; set; }  //单位价值    
        public string Pstock { get; set; }  //       所属库区    
    }

    //调拨表  申请表
    [SugarTable("Allot")]
    public class Allot
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Lid { get; set; }
        public string Lcode { get; set; }  //调拨单号
        public string Lout { get; set; }  //调出仓库 编号,
        public string Lin { get; set; }  //调入仓库 编号,
        public DateTime Ldate { get; set; }  //    时间
        public int Lstatus { get; set; }//    状态  1、待审核，2、已审核，3、未开始，4、部分，5、完成
    }

    //调拨详情
    [SugarTable("AllotDetail")]
    public class AllotDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ADid { get; set; }
        public string ADlbian { get; set; }  //调拨 对应调拨表编号
        public string ADgoods { get; set; }  //物品  编码
        public string ADspec { get; set; }  //计数规格  eg: 箱，个，袋
        public int ADnum { get; set; }//  调拨数量
        public string ADnote { get; set; }//      备注 
    }

    //出库表 报告表
    [SugarTable("Outbound")]
    public class Outbound
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Oid { get; set; }
        public string Ocode { get; set; }  //出库编号
        public string Ofrom { get; set; }  //出库 库区
        public string Otype { get; set; }  //出库的类型原因
        public string Oman { get; set; }  //收货人  可以是供应商
        public DateTime Odate { get; set; }  //时间
        public int Ostatus { get; set; }  //    1、待审核，2、已审核，3、未开始，4、部分，5、完成
    }

    //出库详情
    [SugarTable("OutboundDetail")]
    public class OutboundDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ODid { get; set; }
        public string ODobian { get; set; }  //出库 对应出库表编号
        public string ODgoods { get; set; }  //物品  编码
        public string ODspec { get; set; }  //计数规格  eg: 箱，个，袋
        public int ODnum { get; set; }  //出库数量
        public string ODnote { get; set; }  //         备注 
    }

    //检查、报损 报告表
    [SugarTable("ReportLoss")]
    public class ReportLoss
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Rid { get; set; }
        public string Rcode { get; set; }  //
        public int Rtype { get; set; }  //
        public string Rreason { get; set; }  //
        public string Rman { get; set; }  //
        public int Rstatus { get; set; }  //
    }

    //报损详情
    [SugarTable("ReportLossDetail")]
    public class ReportLossDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int RLDid { get; set; }
        public string RLDrbian { get; set; }  //报损 对应报损表编号
        public string RLDgoods { get; set; }  //物品  编码
        public string RLDspec { get; set; }  //计数规格  eg: 箱，个，袋
        public int RLDnum { get; set; }  //报损数量
        public string Rsolve { get; set; }  //处理方式
        public string RLDnote { get; set; }  //备注       
    }

    //采购申请表
    [SugarTable("Procure")]
    public class Procure
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Pid { get; set; }
        public string Pcode { get; set; }  //         编号
        public string Preason { get; set; }  //         原因,1、到货损失，2、入库损失，3、出库损失，4，转移损失，5，自然损失，6，其他
        public string Pman { get; set; }  //         采购人
        public decimal Pamount { get; set; }  //     共计价格
        public int Rstatus { get; set; }  //                状态  1、待审核，2、通过，处理
    }

    //采购详情
    [SugarTable("ProcureDetail")]
    public class ProcureDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int PDid { get; set; }
        public string PDrbian { get; set; }  // 采购 对应采购表编号
        public string PDgoods { get; set; }  // 物品  编码
        public string PDspec { get; set; }  // 计数规格  eg: 箱，个，袋
        public decimal PDnum { get; set; }  // 采购数量
        public int PDprice { get; set; }  // 单位价格
        public string PDamount { get; set; }  // 总计价格
        public decimal PDnote { get; set; }  // 备注       
    }
    //管理员表
    [SugarTable("Administrator")]
    public class Administrator
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Adid { get; set; }  //ID
        public string AName { get; set; }//姓名
        public string Pwd { get; set; }//密码
    }
    //角色表
    [SugarTable("Roles")]
    public class Roles
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Rdid { get; set; }  //ID
        public string Roles_Name { get; set; }//角色名称
    }
    //管理员角色表
    [SugarTable("Administratorrole")]
    public class Administratorrole
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Admid { get; set; }  //ID
        public int Adminid { get; set; }//姓名
        public int Rolerid { get; set; }//密码
    }
    //菜单表
    [SugarTable("Menu")]
    public class Menu
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Mdid { get; set; }  //ID
        public string MName { get; set; }//父级菜单
        public int Mid { get; set; }//子级菜单
    }
    //角色菜单表
    [SugarTable("Rolemenu")]
    public class Rolemenu
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Rolemenu_id { get; set; }  //ID
        public int Rolemenu_roleid { get; set; }//父级菜单
        public int Rolemenu_menuid { get; set; }//子级菜单
    }
    //调拨表
    [SugarTable("Allottable")]
    public class Allottable
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Allottable_ID { get; set; }
        public string Allottable_danhao { get; set; }
        public int Allottable_diaochu { get; set; }
        public int Allottable_diaoru { get; set; }
        public string Allottable_people { get; set; }
        public int Allottable_state { get; set; }
        public int Allottable_Statess { get; set; }
        public int Allottable_number { get; set; }
        public int iiiiiid { get; set; }
    }
    //调拨详情表
    [SugarTable("Allotedit")]
    public class Allotedit
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Allotedit_id { get; set; }
        public int Allotedit_iiid { get; set; }
        public string Allotedit_bianma { get; set; }
        public string Allotedit_name { get; set; }
        public int Allotedit_kucun { get; set; }
        public int Allotedit_number { get; set; }
        public int Allotedit_shenpi { get; set; }
        public int Allotedit_yichuku { get; set; }
        public int Allotedit_zhouzhuank { get; set; }
        public int Allotedit_danwei { get; set; }
        public string Allotedit_danjia { get; set; }
        public string Allotedit_image { get; set; }
    }

    //添加类型
    [SugarTable("AddType")]
    public class AddType
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ATId { get; set; }
        public string ATName { get; set; }              //类型名称
    }

}
