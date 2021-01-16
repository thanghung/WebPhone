using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_NhaCungCap
    {
        static tbl_NhaCungCap tbl_obj = new tbl_NhaCungCap();

        //Lay bang du lieu
        public List<NhaCungCap> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(NhaCungCap obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public NhaCungCap GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //lay theo ten
        public NhaCungCap GetbyName(string name)
        {
            return tbl_obj.GetbyName(name);
        }


        //Them du lieu 
        public NhaCungCap Insert(NhaCungCap obj)
        {
            return tbl_obj.Insert(obj);
        }
    }
}
