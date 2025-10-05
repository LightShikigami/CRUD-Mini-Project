using System.ComponentModel.DataAnnotations;

namespace CRUD_Mini_Project.Models
{
    public class Method : BaseEntity
    {
        public string code { get; set; }
        public string description { get; set; }
    }
}
