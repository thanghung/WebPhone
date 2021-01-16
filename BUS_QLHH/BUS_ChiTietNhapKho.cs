using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_ChiTietNhapKho
    {
        static tbl_ChiTietNhapKho tbl_obj = new tbl_ChiTietNhapKho();

        //Lay bang du lieu
        public List<ChiTietNhapKho> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(ChiTietNhapKho obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public ChiTietNhapKho GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //lay danh sach chi tiet nhap kho theo hang hoa
        public List<ChiTietNhapKho> GetListByName(string name)
        {
            return tbl_obj.GetListByName(name);
        }

        //Them du lieu 
        public ChiTietNhapKho Insert(ChiTietNhapKho obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(ChiTietNhapKho obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
