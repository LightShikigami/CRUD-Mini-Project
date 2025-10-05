using System.ComponentModel.DataAnnotations;

namespace CRUD_Mini_Project.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedById { get; set; } 
        public DateTime? LastUpdateDate { get; set; } 
        public Guid? LastUpdateById { get; set; }  
        public bool IsActive { get; set; }
    }
}
