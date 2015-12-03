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
        private readonly Entities _entities = new Entities();//datamodell, vars connection skall återlämnas och stängas i disposable

        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }

        public void Delete(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }
            _entities.Contacts.Remove(contact);
        }

        public void Update(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }

            _entities.Entry(contact).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }




        public IQueryable<Contact> FindAllContacts()//används ej
        {
            return _entities.Contacts.AsQueryable();
        }

        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            return _entities.Contacts.OrderBy(c => c.ContactID).Skip(Math.Max(0, _entities.Contacts.Count() - count)).ToList();
        }


        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
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