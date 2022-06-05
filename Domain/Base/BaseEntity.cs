namespace Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedUserId { get; set; }
        public string? UpdatedUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

    }
}
