using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_NhanVien
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show data
        public List<NhanVien> GetAllData()
        {
            return db.NhanViens.ToList();
        }

        //xoa du lieu
        public void Delete(NhanVien obj)
        {
            db.NhanViens.Attach(obj);
            db.NhanViens.Remove(obj);
            db.SaveChanges();
        }

        //lay dữ liệu nhân viên qua ID
        public NhanVien GetbyID(string id)
        {
            return db.NhanViens.Where(x => x.MaNV == id).SingleOrDefault();
        }

        //tim userTK
        public NhanVien TimUserTK(string ten)
        {
            return db.NhanViens.Where(x => x.UserTK == ten).SingleOrDefault();
        }

        //Them du lieu 
        public NhanVien Insert(NhanVien obj)
        {
            db.NhanViens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(NhanVien obj)
        {
            db.NhanViens.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //KT Dang nhap
        public NhanVien CheckAccount(string TK, string pass)
        {
            NhanVien nv = db.NhanViens.Where(x => x.UserTK.Contains(TK) && x.MatKhau.Contains(pass)).SingleOrDefault();
            return nv;
        }

        //Lấy danh sách nhân viên là kế toán
        public List<NhanVien> LayNVKT()
        {
            List<NhanVien> li_nv = db.NhanViens.Where(x => x.ChucVu == "KT").ToList();
            return li_nv;
        }

    }
}
