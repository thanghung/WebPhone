using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_ChiTietNhapKho
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show dữ liệu
        public List<ChiTietNhapKho> GetAllData()
        {
            return db.ChiTietNhapKhoes.ToList();
        }

        //xoa du lieu
        public void Delete(ChiTietNhapKho obj)
        {
            db.ChiTietNhapKhoes.Attach(obj);
            db.ChiTietNhapKhoes.Remove(obj);
            db.SaveChanges();
        }

        //lay id
        public ChiTietNhapKho GetbyID(string id)
        {
            return db.ChiTietNhapKhoes.Where(x => x.MaNK == id).SingleOrDefault();
        }

        //lay danh sach chi tiet nhap kho theo ten hang hoa
        public List<ChiTietNhapKho> GetListByName(string name)
        {
            return db.ChiTietNhapKhoes.Where(x => x.TenHH == name).ToList();
        }

        //Them du lieu 
        public ChiTietNhapKho Insert(ChiTietNhapKho obj)
        {
            db.ChiTietNhapKhoes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(ChiTietNhapKho obj)
        {
            db.ChiTietNhapKhoes.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
