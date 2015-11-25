using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rf222cz_1_2_aventyrliga_kontakter.Models.Repositories
{
    public interface IRepository : IDisposable
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        void Save();

        IQueryable<Contact> FindAllContacts();
        Contact GetContactById(int contactId);
        List<Contact> GetLastContacts(int count = 20);
    }
}
