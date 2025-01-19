namespace PC_ControllerApi.Models
{
    public class User : BaseEntity
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public Guid PC_Id { get; set; }

        public string AdditionalInfo { get; set; }
    }
}
