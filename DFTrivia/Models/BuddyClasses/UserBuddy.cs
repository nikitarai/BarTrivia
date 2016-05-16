using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DFTrivia.Models
{
    [MetadataType(typeof(UserBuddy))]

    public partial class User
    {
         
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
            set { }
        }
    }

    sealed class UserBuddy
    {
        public int UserID { get; set; }

        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        public string UserName { get; set; }
        public Nullable<int> UserScore { get; set; }
        public string ImgSource { get; set; }
    }
}