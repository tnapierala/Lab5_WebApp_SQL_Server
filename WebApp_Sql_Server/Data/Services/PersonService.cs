using Microsoft.EntityFrameworkCore;
using System;
using WebApp_Sql_Server.Data.Models;
using WebApp_Sql_Server.Data.ViewModels;

namespace WebApp_Sql_Server.Data.Services
{
    public class PersonService
    {
        private AzureDbContext _context;

        public PersonService(AzureDbContext context)
        {
            _context = context;
        }

        public void AddPerson(PersonVM person)
        {
            var _person = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            _context.Persons.Add(_person);
            _context.SaveChanges();
            //_context.SaveChangesAsync();
        }

        public Person? GetPersonById(Guid personId) => _context.Persons.FirstOrDefault(p => p.PersonId == personId);

        public Person? EditPersonById(Guid personId, PersonVM person)
        {
            var _pId  = _context.Persons.FirstOrDefault(p => p.PersonId == personId);
            if (_pId != null)
            {
                _pId.FirstName = person.FirstName;
                _pId.LastName = person.LastName;
                _context.SaveChanges();
            }

            return _pId;
        }
            

        public void DeletePersonById(Guid personId)
        {
            var _pId = _context.Persons.FirstOrDefault(p => p.PersonId == personId);
            if (_pId != null)
            {
                _context.Persons.Remove(_pId);
                _context.SaveChanges();
            }
        }
    }
}
