using rf222cz_1_2_aventyrliga_kontakter.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rf222cz_1_2_aventyrliga_kontakter.Models.Repositories
{
    public class Repositroy : IRepository, IDisposable
    {
        private Entities _context = new Entities();//datamodell //återlämna och stänga connection

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            if (_context.Entry(contact).State == EntityState.Detached)
            {
                _context.Contacts.Attach(contact);
            }

            _context.Entry(contact).State = EntityState.Modified;
        }
        



        public IQueryable<Contact> FindAllContacts()
        {
            return _context.Contacts.AsQueryable();//datamodell ej en fråga
        }

        public Contact GetContactById(int contactId)
        {
            return _context.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            //IQueryable allContacts = FindAllContacts();
            //var hi = allContacts.Reverse().Take(count).Reverse();
            throw new NotImplementedException();
        }


        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}