using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Mariage.Models
{
    public class ContactModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Sujet { get; set; }
        public string Message  { get; set; }
        [DisplayName("Fichier joint")]
        public HttpPostedFileBase Files  { get; set; }
    }
}