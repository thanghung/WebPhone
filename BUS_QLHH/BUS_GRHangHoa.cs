using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
    public class BUS_GRHangHoa
    {
        static tbl_GRHangHoa tbl_obj = new tbl_GRHangHoa();

        //Lay bang du lieu
        public List<GroupHangHoa> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(GroupHangHoa obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public GroupHangHoa GetbyID(string id)
        {
            return tbl_obj.GetbyID(id);
        }

        //lay theo ten
        public GroupHangHoa GetbyName(string name)
        {
            return tbl_obj.GetbyName(name);
        }

        //Them du lieu 
        public GroupHangHoa Insert(GroupHangHoa obj)
        {
            return tbl_obj.Insert(obj);
        }
    }
}
