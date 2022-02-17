using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_7.Models;
using Day_7.Implements;
using Day_7.Interface;
using Newtonsoft.Json;

namespace Day_7.Controllers
{
    public class PeopleController : Controller
    {
        public PeopleInterface _people;
        public PeopleController(PeopleInterface people){
            _people = people;
        }
        public const string DELETED = "delete";
        public const string DELETED_NAME = "deteted_name";
        private List<string> GetDeleteList(){
            string list = HttpContext.Session.GetString(DELETED);
            if(list != null){
                return JsonConvert.DeserializeObject<List<string>>(list);
            }
            return new List<string>();
        }
        private void SaveDeleteList(List<string> ls) {
            string jsonlist = JsonConvert.SerializeObject(ls);
            HttpContext.Session.SetString(DELETED, jsonlist);
        }
        public IActionResult Index()
        {
            string deteledName = HttpContext.Session.GetString(DELETED_NAME);
            if(deteledName != null){
                ViewBag.isConfirm = true;
                ViewBag.nameConfirm = deteledName;
                HttpContext.Session.Remove(DELETED_NAME);
            }
            ViewBag.peopleList = _people.Index();
            return View();
        }
        public IActionResult Detail(int id) {
            var personDetail = _people.Index().Where(x=>x.Id == id).FirstOrDefault();
            return View(personDetail);
        }
        public IActionResult Add(){
            return View();
        }
        [HttpPost]
        public IActionResult Add(PersonModel person){
            _people.Add(person);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id){
            var personEdit = (from person in _people.Index()
                            where person.Id == id
                            select person).FirstOrDefault();
            if(personEdit != null){
                return View(personEdit);
            }
            return RedirectToAction("Index");
        }

        // Query string thif lay ow trong HttpContext.Request.queryString
        // Con bth thi la Json Object
        // Ngoai ra con co nhieu kieu Post khac nuwa
        
        [HttpPost]
        public IActionResult Edit(PersonModel personAfterEdit){
            _people.Edit(personAfterEdit);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(int id, string? Redirect){
            bool isDelete = false;
            string name = (from x in _people.Index() where x.Id == id select x.FirstName + " " + x.LastName).FirstOrDefault().ToString();
            if(_people.Delete(id)){
                List<string> list = GetDeleteList();
                list.Add(name);
                HttpContext.Session.SetString(DELETED_NAME, name);
                SaveDeleteList(list);
                isDelete = true;
            }
            if(!string.IsNullOrEmpty(Redirect)){
                return RedirectToAction("Index");
            }
            if(isDelete){
                return Ok();
            }
            return BadRequest();
        }

    }
}