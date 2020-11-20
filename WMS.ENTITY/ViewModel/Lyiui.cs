using System;
using System.Collections.Generic;
using System.Text;
using WMS.ENTITY.InitialTable;

namespace WMS.ENTITY.ViewModel
{
    public class Lyiui
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }

        public List<Allottable> data { get; set; }
    }
}
