using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHH
{
    public class tbl_GRHangHoa
    {
        QuanLyHangHoaEntities db = new QuanLyHangHoaEntities();

        //Show dữ liệu
        public List<GroupHangHoa> GetAllData()
        {
            return db.GroupHangHoas.OrderBy(x => x.TenGroupHang).ToList();
        }

        //xoa du lieu
        public void Delete(GroupHangHoa obj)
        {
            db.GroupHangHoas.Attach(obj);
            db.GroupHangHoas.Remove(obj);
            db.SaveChanges();
        }

        //lay id
        public GroupHangHoa GetbyID(string id)
        {
            return db.GroupHangHoas.Where(x => x.MaGRHang == id).SingleOrDefault();
        }

        //lay theo ten
        public GroupHangHoa GetbyName(string name)
        {
            return db.GroupHangHoas.Where(x => x.TenGroupHang == name).SingleOrDefault();
        }

        //Them du lieu 
        public GroupHangHoa Insert(GroupHangHoa obj)
        {
            db.GroupHangHoas.Add(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
