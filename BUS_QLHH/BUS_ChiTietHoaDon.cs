using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_ChiTietHoaDon
    {
        static tbl_ChiTietHoaDon tbl_obj = new tbl_ChiTietHoaDon();

        //Lay bang du lieu
        public List<ChiTietHoaDon> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(ChiTietHoaDon obj)
        {
             tbl_obj.Delete(obj);
        }

        //lay id
        public ChiTietHoaDon GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //lay danh sách cthd theo mahd
        public List<ChiTietHoaDon> GetListbyID(string id)
        {
            return tbl_obj.GetListbyID(id);
        }

        //Them du lieu 
        public ChiTietHoaDon Insert(ChiTietHoaDon obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(ChiTietHoaDon obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
