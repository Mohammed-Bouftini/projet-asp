using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Versioning;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName ="emailEr",ErrorMessageResourceType =typeof(Resources.ModelsResources.Account.ResourceAccount))]
        [EmailAddress(ErrorMessageResourceName = "emailErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Account.ResourceAccount))]
        [Display(Name = "email", ResourceType = typeof(Resources.ModelsResources.Account.ResourceAccount))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "pwdEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Account.ResourceAccount))]
        [DataType(DataType.Password)]
        [Display(Name = "pwd", ResourceType = typeof(Resources.ModelsResources.Account.ResourceAccount))]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}