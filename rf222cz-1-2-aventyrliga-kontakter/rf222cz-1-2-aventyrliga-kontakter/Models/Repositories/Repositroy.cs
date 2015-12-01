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
        private readonly Entities _entities = new Entities();//datamodell //återlämna och stänga connection

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




        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts.AsQueryable();//datamodell ej en fråga
        }

        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            List<Contact> contacts = _entities.Contacts.ToList();
            return contacts.Skip(Math.Max(0, contacts.Count() - count)).ToList();
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