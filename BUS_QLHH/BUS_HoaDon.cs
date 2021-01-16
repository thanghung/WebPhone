using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_HoaDon
    {
        static tbl_HoaDon tbl_obj = new tbl_HoaDon();

        //Lay bang du lieu
        public List<HoaDon> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(HoaDon obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public HoaDon GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //Them du lieu 
        public HoaDon Insert(HoaDon obj)
        {
            return tbl_obj.Insert(obj);
        }
    }
}
