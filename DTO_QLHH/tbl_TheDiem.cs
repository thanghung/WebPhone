using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_TheDiem
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();
        public List<TheDiem> GetAllData()
        {
            return db.TheDiems.ToList();
        }

        //xoa du lieu
        public void Delete(TheDiem obj)
        {
            db.TheDiems.Attach(obj);
            db.TheDiems.Remove(obj);
            db.SaveChanges();
        }

        //lay id khach hang
        public TheDiem GetbyIDKH(string id)
        {
            return db.TheDiems.Where(x => x.IDKH == id).SingleOrDefault();
        }

        //Kiểm tra id khach hang
        public TheDiem CheckID(string id)
        {
            return db.TheDiems.Where(x => x.IDKH == id).SingleOrDefault();
        }

        //Lấy thẻ điểm theo ID
        public TheDiem GetByID(string id)
        {
            return db.TheDiems.Where(x => x.ID == id).SingleOrDefault();
        }

        //Them du lieu 
        public TheDiem Insert(TheDiem obj)
        {
            db.TheDiems.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(TheDiem obj)
        {
            db.TheDiems.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
