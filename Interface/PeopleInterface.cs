using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_7.Models;

namespace Day_7.Interface
{
    public interface PeopleInterface
    {
        public List<PersonModel> Index();
        public void Add(PersonModel person);
        public void Edit(PersonModel personAfterEdit);
        public bool Delete(int id);
    }
}