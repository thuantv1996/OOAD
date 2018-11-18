using System.Data.Entity;

namespace DAO.Interface
{
    public interface IDonThuocServices : IBaseDAO<DONTHUOC>
    {
        string FindByParameter(DbContext db, string maHoSo, out DONTHUOC entity);
    }
}
