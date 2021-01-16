using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLHH
{
     public class BUS_UserGroup
    {
        static tbl_UserGroup tbl_obj = new tbl_UserGroup();

        //Lay bang du lieu
        public List<UserGroup> GetAllData()
        {
            return tbl_obj.GetAllData();
        }

        //xoa du lieu
        public void Delete(UserGroup obj)
        {
            tbl_obj.Delete(obj);
        }

        //lay id
        public UserGroup GetbyID(string userTK)
        {
            return tbl_obj.GetbyUserTK(userTK);
        }

        //Them du lieu 
        public UserGroup Insert(UserGroup obj)
        {
            return tbl_obj.Insert(obj);
        }

        //Cap nhap du lieu
        public void Update(UserGroup obj)
        {
            tbl_obj.Update(obj);
        }
    }
}
