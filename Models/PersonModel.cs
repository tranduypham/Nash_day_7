using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Day_7.Models
{
    public class PersonModel
    {
        private static int index = 0;
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BindProperty]
        public int Gender { get; set; }
        public int[] Genders = new [] {0, 1};
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age {
            get{
                DateTime date;
                if(DateOfBirth!=null){
                    date = Convert.ToDateTime(DateOfBirth);
                }else {
                    date = DateTime.Now;
                }
                return DateTime.Now.Year - date.Year;
            }
        }
        public bool IsGraduate { get; set; }


        public int YearOfBirth {
            get {
                return Convert.ToDateTime(DateOfBirth).Year;
            }
        }

        public PersonModel(){
            Id = index++;
            IsGraduate = false;
        }
        public string showInfo(){
            return $"Full-Name: {FirstName} {LastName} Age: {Age} Gender: {(Gender==0 ? "Female" : "Male")} City: {BirthPlace} \n";
        }
    }
}