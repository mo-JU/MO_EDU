using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IAdminRepository
    {
        ICollection<Admin> GetAdmin();
        Admin GetAdminById(int id);
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
