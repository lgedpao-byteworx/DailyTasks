namespace DailyTasks.Domain.Entities
{
    public class DailyTask
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
