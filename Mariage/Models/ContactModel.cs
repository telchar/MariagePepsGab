using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Mariage.Models
{
    public class ContactModel : BaseModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "L'email saisi n'est pas valide.")]
        [Required(ErrorMessage = "Merci de renseigner une adresse email pour que nous puissions vous répondre.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Merci de mettre un sujet à votre message.")]
        public string Sujet { get; set; }
        [Required(ErrorMessage = "Merci de saisir votre message.")]
        public string Message  { get; set; }
        [DisplayName("Fichier joint")]
        public HttpPostedFileBase Files  { get; set; }
    }
}