using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_ChiTietHoaDon
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();
        //Lay bang du lieu
        public List<ChiTietHoaDon> GetAllData()
        {
            return db.ChiTietHoaDons.ToList();
        }

        //xoa du lieu
        public void Delete(ChiTietHoaDon obj)
        {
            db.ChiTietHoaDons.Attach(obj);
            db.ChiTietHoaDons.Remove(obj);
            db.SaveChanges();
        }

        //lay id cthd
        public ChiTietHoaDon GetbyID(string id)
        {
            return db.ChiTietHoaDons.Where(x => x.MaCTHD == id).SingleOrDefault();
        }

        //lay danh sách cthd theo mahd
        public List<ChiTietHoaDon> GetListbyID(string id)
        {
            return db.ChiTietHoaDons.Where(x => x.MaHD == id).ToList();
        }

        //Them du lieu 
        public ChiTietHoaDon Insert(ChiTietHoaDon obj)
        {
            db.ChiTietHoaDons.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(ChiTietHoaDon obj)
        {
            db.ChiTietHoaDons.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
