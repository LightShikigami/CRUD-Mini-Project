using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Mini_Project.Models
{
    public class Analyse : BaseEntity
    {
        public string code { get; set; }
        public string description { get; set; }
        public Guid parameter_id { get; set; }
        public Guid method_id { get; set; }
        public Guid sample_type_id { get; set; }
        public DateTime? lead_time { get; set; }

        [ForeignKey("parameter_id")]
        public virtual Parameter? parameter { get; set; }

        [ForeignKey("method_id")]
        public virtual Method? method { get; set; }

        [ForeignKey("sample_type_id")]
        public virtual SampleType? sample_type { get; set; }
    }
}
