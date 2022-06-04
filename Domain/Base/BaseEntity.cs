namespace Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

    }
}
