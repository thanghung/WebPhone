using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_DangNhapKhachHang
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //lay id
        public DangNhapKhachHang GetbyUserTK(string user, string pass)
        {
            return db.DangNhapKhachHangs.Where(x => x.userDN == user && x.MatKhauDN == pass).SingleOrDefault();
        }

        //Check key
        public DangNhapKhachHang CheckKey(string user)
        {
            return db.DangNhapKhachHangs.Where(x => x.userDN == user).SingleOrDefault();
        }

        //Them du lieu 
        public DangNhapKhachHang Insert(DangNhapKhachHang obj)
        {
            db.DangNhapKhachHangs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //xoa du lieu
        public void Delete(DangNhapKhachHang obj)
        {
            db.DangNhapKhachHangs.Attach(obj);
            db.DangNhapKhachHangs.Remove(obj);
            db.SaveChanges();
        }

        //Cap nhap du lieu
        public void Update(DangNhapKhachHang obj)
        {
            db.DangNhapKhachHangs.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
