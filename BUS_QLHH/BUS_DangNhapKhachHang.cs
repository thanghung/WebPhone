using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_DangNhapKhachHang
    {
        static  tbl_DangNhapKhachHang tbl_obj = new tbl_DangNhapKhachHang();

        //lay id
        public DangNhapKhachHang GetbyUserTK(string user, string pass)
        {
            return tbl_obj.GetbyUserTK(user, pass);
        }

        //Check key
        public DangNhapKhachHang CheckKey(string user)
        {
            return tbl_obj.CheckKey(user);
        }

        //Them du lieu 
        public DangNhapKhachHang Insert(DangNhapKhachHang obj)
        {
            return tbl_obj.Insert(obj);
        }

        //xoa du lieu
        public void Delete(DangNhapKhachHang obj)
        {
            tbl_obj.Delete(obj);
        }

        //Cap nhap du lieu
        public void Update(DangNhapKhachHang obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
