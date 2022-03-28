using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.UserModels
{
    public class UserListClass
    {

        public UserListClass()
        {
            users = new List<kullanici>();
            roles = new List<rol>();
       
        }
        public List<kullanici> users { get; set; }
        public List<rol> roles { get; set; }

    }
}