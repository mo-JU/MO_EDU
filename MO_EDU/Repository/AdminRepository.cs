using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        public AdminRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Admin> GetAdmin()
        {
            return _context.Admins.OrderBy(p => p.AdminID).ToList();
        }
        public Admin GetAdminById(int id)
        {
            return _context.Admins.FirstOrDefault(e => e.AdminID == id);
        }

        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }


        public void UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }

        public void DeleteAdmin(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }
    }
}
