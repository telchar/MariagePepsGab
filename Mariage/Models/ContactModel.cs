using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mariage.Models
{
    public class ContactModel
    {
        public string Email;
        public string Sujet;
        public string Message;
        public HttpPostedFileBase Files;
    }
}