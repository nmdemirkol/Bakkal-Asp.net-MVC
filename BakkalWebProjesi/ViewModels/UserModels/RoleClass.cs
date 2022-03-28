using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.UserModels
{
    public class RoleClass
    {
        public RoleClass()
        {
            userCount = new int();
            role = new rol();

        }
        public int userCount { get; set; }
        public rol role { get; set; }
    }
}