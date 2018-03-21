using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGL.DevTest.JSONWebserviceConsumer.Models
{

    /// <summary>
    ///Pet class
    /// </summary>
    public class Pet
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    /// <summary>
    ///People class 
    /// </summary>
    public class People
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }
    }
    /// <summary>
    /// People view model class
    /// </summary>
    public class PeopleViewModel
    {
        public string gender { get; set; }

        public IList<string> petname { get; set; }
    }
}