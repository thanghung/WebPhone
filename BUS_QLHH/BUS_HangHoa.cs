using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_HangHoa
    {
        static tbl_HangHoa tbl_obj = new tbl_HangHoa();

        //Lay bang du lieu
        public List<HangHoa> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(HangHoa obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay hh theo id
        public HangHoa GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }


        //lay hh theo ten
        public HangHoa GetbyName(string name)
        {
            return tbl_obj.GetbyName(name);
        }

        //lay danh sach hang theo id nhanh vien
        public List<HangHoa> GetbyIDNV(string id)
        {
            return tbl_obj.GetbyIDNV(id);
        }

        //Cap nhap du lieu
        public void Update(HangHoa obj)
        {
            tbl_obj.Update(obj);
        }

        //Them du lieu 
        public HangHoa Insert(HangHoa obj)
        {
            return tbl_obj.Insert(obj);
        }

        //tim kiem
        public List<HangHoa> Search(string key)
        {
            return tbl_obj.Search(key);
        }
    }
}
