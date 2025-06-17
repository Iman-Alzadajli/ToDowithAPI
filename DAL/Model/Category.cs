using DAL.Model;
using DAL.Model.UserMangment;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITODO.Model
{
    public class Category : BaseModel
    {

        public string Name { get; set; }

        public List<Todo> todos { get; set; } = new List<Todo>();


        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
      
        public ApplicationUser? User { get; set; }

    }
}
