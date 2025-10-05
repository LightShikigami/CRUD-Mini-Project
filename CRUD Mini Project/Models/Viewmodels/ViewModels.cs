namespace CRUD_Mini_Project.Models.Viewmodel
{
    public class AnalyseViewModel
    {
        public Guid Id { get; set; }

        public string code { get; set; }
        public string description { get; set; }

        public Guid parameter_id { get; set; }
        public Guid method_id { get; set; }
        public Guid sample_type_id { get; set; }

        public Parameter parameter { get; set; }
        public Method method { get; set; }
        public SampleType sampleType { get; set; }

        public DateTime? lead_time { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class MethodViewModel
    {
        public Guid Id { get; set; }

        public string code { get; set; }
        public string description { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class ParameterViewModel
    {
        public Guid Id { get; set; }

        public string code { get; set; }
        public string description { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class SampleTypeViewModel
    {
        public Guid Id { get; set; }

        public string code { get; set; }
        public string description { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
