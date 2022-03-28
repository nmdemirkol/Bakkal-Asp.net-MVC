using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.UserModels
{
    public class UserClass
    {

        public UserClass()
        {
            user = new kullanici();
            roles = new List<rol>();
       
        }
        public kullanici user { get; set; }
        public List<rol> roles { get; set; }

    }
}