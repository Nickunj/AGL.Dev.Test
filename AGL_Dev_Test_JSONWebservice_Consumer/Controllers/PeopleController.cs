using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AGL.DevTest.JSONWebserviceConsumer.Models;
using AGL.DevTest.JSONWebserviceConsumer.Helper;
using System.Web.Configuration;

namespace AGL.DevTest.JSONWebserviceConsumer.Controllers
{
    public class PeopleController : Controller
    {
        /// <summary>
        /// Default controller function
        /// </summary>
        /// <returns>returns default view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Name: GetPetsByOwnerGenderAsc
        /// Parameters: NONE
        /// TYPE: HttpGet
        /// SUMMARY: This method consumes JSON webservice, deserialises the JSON string to People Object and filters it to get desrired output
        /// </summary>
        /// <returns>RETURNS: View model object that contains cat's name in ascending order grouped by owner's gender</returns>
        [HttpGet]
        public ActionResult GetPetsByOwnerGenderAsc()
        {
            string getPeopleDataFunction = WebConfigurationManager.AppSettings["GetPeopleData"];
            //Call  Service helper to get serialized JSON object of type List<People>
            List<People> peopleObject = ServiceHelper.GetSerializedJsonDataFromWebService<List<People>>(getPeopleDataFunction);

            //process object to get view model object which contains cat's name in ascending order group by owner's gender
            var item = from people in peopleObject
                       where people.pets != null && people.pets.Any(p => p.type.ToLower() == "cat")
                       group people by people.gender into grpPeople
                       select new PeopleViewModel() { gender = grpPeople.Key, petname = grpPeople.SelectMany(grp => grp.pets.Where(pet => pet.type.ToLower() == "cat")).Select(cat => cat.name).OrderBy(name => name).ToList() };

            // convert IEnumerable to IList
            IList<PeopleViewModel> peopleViewModelObject = item.ToList();

            //return View with View Model object
            return View(peopleViewModelObject);
        }
    }
}