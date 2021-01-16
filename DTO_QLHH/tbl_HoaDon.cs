using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_HoaDon
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();
        //Show data
        public List<HoaDon> GetAllData()
        {
            return db.HoaDons.ToList();
        }

        //xoa du lieu
        public void Delete(HoaDon obj)
        {
            db.HoaDons.Attach(obj);
            db.HoaDons.Remove(obj);
            db.SaveChanges();
        }

        //lay id
        public HoaDon GetbyID(string id)
        {
            return db.HoaDons.Where(x => x.MaHD == id).SingleOrDefault();
        }

        //Them du lieu 
        public HoaDon Insert(HoaDon obj)
        {
            db.HoaDons.Add(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
