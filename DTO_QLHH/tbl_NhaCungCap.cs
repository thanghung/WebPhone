using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_NhaCungCap
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show data
        public List<NhaCungCap> GetAllData()
        {
            return db.NhaCungCaps.OrderBy(x => x.TenNCC).ToList();
        }

        //xoa du lieu
        public void Delete(NhaCungCap obj)
        {

            db.NhaCungCaps.Attach(obj);
            db.NhaCungCaps.Remove(obj);
            db.SaveChanges();
        }

        //lay Nhà cung cấp qua ID
        public NhaCungCap GetbyID(string id)
        {
            return db.NhaCungCaps.Where(x => x.MaNCC == id).SingleOrDefault();
        }

        //lay theo ten
        public NhaCungCap GetbyName(string name)
        {
            return db.NhaCungCaps.Where(x => x.TenNCC == name).SingleOrDefault();
        }

        //Them du lieu 
        public NhaCungCap Insert(NhaCungCap obj)
        {
            db.NhaCungCaps.Add(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
