using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_7.Interface;
using Day_7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_7.Implements
{
    public class PeopleImplement : PeopleInterface
    {
        public static List<PersonModel> people = new List<PersonModel>{
            new PersonModel{
                FirstName = "Duy",
                LastName = "Pham",
                Gender = 1,
                DateOfBirth = "1999/12/20",
                PhoneNumber = "0946301025",
                BirthPlace = "Ha noi",
                IsGraduate = true
            },
            new PersonModel{
                FirstName = "Hoa",
                LastName = "Ho Thi",
                Gender = 0,
                DateOfBirth = "2001/10/10",
                PhoneNumber = "0946301025",
                BirthPlace = "Thanh Hoa",
                IsGraduate = true
            },
            new PersonModel{
                FirstName = "Long",
                LastName = "Do Tung",
                Gender = 1,
                DateOfBirth = "1997/02/20",
                PhoneNumber = "0946301025",
                BirthPlace = "Phu Tho",
                IsGraduate = true
            },
        };
        public void Add(PersonModel person)
        {
            var newPerson = new PersonModel{
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
                IsGraduate = person.IsGraduate
            };
            people.Add(newPerson);
        }

        public bool Delete(int id)
        {
            var deleted = people.Where(person=>person.Id == id).FirstOrDefault();
            if(deleted != null){
                if(people.Remove(deleted)){
                    return true;
                }
            }
            return false;
        }

        public void Edit(PersonModel personAfterEdit)
        {
            var personEdit = people.Where(x=>x.Id == personAfterEdit.Id).FirstOrDefault();
            if(personEdit != null){
                personEdit.FirstName = personAfterEdit.FirstName;
                personEdit.LastName = personAfterEdit.LastName;
                personEdit.Gender = personAfterEdit.Gender;
                personEdit.BirthPlace = personAfterEdit.BirthPlace;
                personEdit.DateOfBirth = personAfterEdit.DateOfBirth;
                personEdit.PhoneNumber = personAfterEdit.PhoneNumber;
                personEdit.IsGraduate = personAfterEdit.IsGraduate;
            }
        }

        public List<PersonModel> Index()
        {
            return people;
        }
    }
}