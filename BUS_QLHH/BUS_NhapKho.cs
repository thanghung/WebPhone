using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_NhapKho
    {
        tbl_NhapKho tbl_obj = new tbl_NhapKho();

        //Lay bang du lieu
        public List<NhapKho> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(NhapKho obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public NhapKho GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //Them du lieu 
        public NhapKho Insert(NhapKho obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(NhapKho obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
