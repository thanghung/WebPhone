using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_KhachHang
    {
        static tbl_KhachHang tbl_obj = new tbl_KhachHang();

        //Lay bang du lieu
        public List<KhachHang> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(KhachHang obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public KhachHang GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //Them du lieu 
        public KhachHang Insert(KhachHang obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(KhachHang obj)
        {
           tbl_obj.Update(obj);
        }

        //KT khach hang
        public KhachHang CheckKey(string email, string ten, string sdt)
        {
            return tbl_obj.CheckKey(email, ten, sdt);
        }
    }
}
