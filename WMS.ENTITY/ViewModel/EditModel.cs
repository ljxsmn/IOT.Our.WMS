using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.ENTITY.ViewModel
{
    public class EditModel
    {
        public int Allottable_ID { get; set; }
        public string Allottable_danhao { get; set; }
        public int Allottable_diaochu { get; set; }
        public int Allottable_diaoru { get; set; }
        public string Allottable_people { get; set; }
        public int Allottable_state { get; set; }
        public int Allottable_Statess { get; set; }
        public int Allottable_number { get; set; }
        public int Rid { get; set; }
        public string Rcode { get; set; }  //库区 编码  
        public string Rname { get; set; }  //库区 名称  eg:暂存区，商品去，报废区
        public string Rareawarm { get; set; }  //温区   eg: 常温，干杂区
        public string Rwh { get; set; }  //所属仓库
        public int Allotedit_id { get; set; }
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
        public int iiiiiid { get; set; }
    }
}
