using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_KhachHang
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();
        //Show data
        public List<KhachHang> GetAllData()
        {
            return db.KhachHangs.OrderBy(x => x.TenKH).ToList();
        }

        //xoa du lieu
        public void Delete(KhachHang obj)
        {
            db.KhachHangs.Attach(obj);
            db.KhachHangs.Remove(obj);
            db.SaveChanges();
        }

        //lay theo MaKH
        public KhachHang GetbyID(string id)
        {
            return db.KhachHangs.Where(x => x.MaKH == id).SingleOrDefault();
        }

        //Them du lieu 
        public KhachHang Insert(KhachHang obj)
        {
            db.KhachHangs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(KhachHang obj)
        {
            db.KhachHangs.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //KT khach hang
        public KhachHang CheckKey(string email, string ten, string sdt)
        {
            return db.KhachHangs.Where(x => x.Email == email && x.TenKH == ten && x.SDT == sdt).SingleOrDefault();
        }
    }
}
