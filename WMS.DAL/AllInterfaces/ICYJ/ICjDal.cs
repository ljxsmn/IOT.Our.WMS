using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WMS.ENTITY;
using WMS.ENTITY.InitialTable;
using WMS.ENTITY.ViewModel;

namespace WMS.DAL.AllInterfaces
{
    public interface ICjDal
    {
        //到货登记
        public List<ViewModel> DHDJ();
        //快捷到货
        public List<ViewModel> KJDH();
        //到货详情表(原料)
        public List<ViewModel> DHXQYL();
        //到货详情表(产品)
        public List<ViewModel> DHXQCP();
        //快捷到货登记详情
        public ViewModel KJDJXQ(int ids);
        //快捷到货登记（反填）
        public ViewModel FanT(int ids);
        //快捷到货登记（编辑）
        public int UPdete(ViewModel vm);
        //快捷到货登记详情
        public ViewModel KJXQ(int ids);
        //到货记录
        public List<ViewModel> DHJL();
        //绑定下拉(供应商)
        public List<ViewModel> BangGYS();
        //绑定下拉(产品品类)
        public List<ViewModel> BangPL();
    }
}
