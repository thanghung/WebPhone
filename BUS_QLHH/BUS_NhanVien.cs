using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_NhanVien
    {
        static tbl_NhanVien tbl_obj = new tbl_NhanVien();

        //Lay bang du lieu
        public List<NhanVien> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(NhanVien obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public NhanVien GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //tim userTK
        public NhanVien TimUserTK(string ten)
        {
            return tbl_obj.TimUserTK(ten);
        }

        //Them du lieu 
        public NhanVien Insert(NhanVien obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(NhanVien obj)
        {
            tbl_obj.Update(obj);
        }

        //KT Login
        public NhanVien CheckAccount(string TK, string pass)
        {
            return tbl_obj.CheckAccount(TK, pass);
        }

        //Lấy danh sách nhân viên là kế toán
        public List<NhanVien> LayNVKT()
        {
            return tbl_obj.LayNVKT();
        }

        //Lấy danh dữ liệu nhân viên là kế toán
        public NhanVien LayDuLieu1NV()
        {
            List<NhanVien> li_nv = tbl_obj.LayNVKT();
            NhanVien _nv = new NhanVien();

            foreach(NhanVien nv in li_nv) 
            {
                _nv = nv;
                break;
            }
                
            return _nv;
        }
    }
}
