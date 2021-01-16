using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_UserGroup
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show data
        public List<UserGroup> GetAllData()
        {
            return db.UserGroups.ToList();
        }

        //xoa du lieu
        public void Delete(UserGroup obj)
        {
            db.UserGroups.Attach(obj);
            db.UserGroups.Remove(obj);
            db.SaveChanges();
        }

        //lay id
        public UserGroup GetbyUserTK(string name)
        {
            return db.UserGroups.Where(x => x.UserTK == name).SingleOrDefault();
        }

        //Them du lieu 
        public UserGroup Insert(UserGroup obj)
        {
            db.UserGroups.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(UserGroup obj)
        {
            db.UserGroups.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
