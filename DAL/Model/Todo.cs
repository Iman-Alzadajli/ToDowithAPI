using DAL.Model;
using DAL.Model.UserMangment;
using System.ComponentModel.DataAnnotations.Schema;

public enum TodoPiriority
{
    Low,
    Medium,
    High,
    Urgent
}

namespace APITODO.Model
{
    public class Todo : BaseModel
    {
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public TodoPiriority piriority { get; set; } = TodoPiriority.Medium;
        public bool IsCompeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
