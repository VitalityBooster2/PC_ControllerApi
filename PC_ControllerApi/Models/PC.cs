namespace PC_ControllerApi.Models
{
    public class PC : BaseEntity
    {
        public new Guid Id { get; set; }
        public string PCName { get; set; } = null!;

    }
}
