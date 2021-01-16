using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_HangHoa
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show Data
        public List<HangHoa> GetAllData()
        {
            return db.HangHoas.OrderBy(x => x.TenHang).ToList();
        }

        //xoa du lieu
        public void Delete(HangHoa obj)
        {
            db.HangHoas.Attach(obj);
            db.HangHoas.Remove(obj);
            db.SaveChanges();
        }

        //lay hh theo MaHang
        public HangHoa GetbyID(string id)
        {
            return db.HangHoas.Where(x => x.MaHang == id).SingleOrDefault();
        }

        //lay hh theo ten
        public HangHoa GetbyName(string name)
        {
            return db.HangHoas.Where(x => x.TenHang == name).SingleOrDefault();
        }

        //lay danh sach hang theo Ma nhanh vien
        public List<HangHoa> GetbyIDNV(string id)
        {
            return db.HangHoas.Where(x => x.IDNV == id).ToList();
        }

        //Them du lieu 
        public HangHoa Insert(HangHoa obj)
        {
            db.HangHoas.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(HangHoa obj)
        {
            db.HangHoas.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //Tim Kiem
        public List<HangHoa> Search(string key)
        {
            return db.HangHoas.Where(x => x.TenHang.Trim().ToUpper().IndexOf(key.ToUpper().ToString().Trim()) != -1 || x.TenGRH.ToUpper().Trim() == key.ToUpper().Trim()).ToList();
        }
    }
}
