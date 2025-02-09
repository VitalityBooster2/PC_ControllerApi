namespace PC_ControllerApi.Models
{
    public class User : BaseEntity
    {

        public new Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public Guid PC_Id { get; set; }

        public string AdditionalInfo { get; set; } = null!;
    }
}
