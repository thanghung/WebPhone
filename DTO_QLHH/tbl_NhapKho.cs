using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_NhapKho
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show data
        public List<NhapKho> GetAllData()
        {
            return db.NhapKhoes.ToList();
        }

        //xoa du lieu
        public void Delete(NhapKho obj)
        {
            db.NhapKhoes.Attach(obj);
            db.NhapKhoes.Remove(obj);
            db.SaveChanges();
        }

        //lay id
        public NhapKho GetbyID(string id)
        {
            return db.NhapKhoes.Where(x => x.MaNK == id).SingleOrDefault();
        }

        //Them du lieu 
        public NhapKho Insert(NhapKho obj)
        {
            db.NhapKhoes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(NhapKho obj)
        {
            db.NhapKhoes.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
