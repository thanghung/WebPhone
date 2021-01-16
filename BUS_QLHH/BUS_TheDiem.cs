using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_TheDiem
    {
        static tbl_TheDiem tbl_obj = new tbl_TheDiem();

        public List<TheDiem> GetAllData()
        {
            return tbl_obj.GetAllData() ;
        }

        //xoa du lieu
        public void Delete(TheDiem obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public TheDiem GetbyIDKH(string id)
        {
            return tbl_obj.GetbyIDKH(id);
        }

        //lay id khach hang
        public TheDiem CheckID(string id)
        {
            return tbl_obj.CheckID(id);
        }

        //Lấy thẻ điểm theo ID
        public TheDiem GetByID(string id)
        {
            return tbl_obj.GetByID(id);
        }

        //Them du lieu 
        public TheDiem Insert(TheDiem obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(TheDiem obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
