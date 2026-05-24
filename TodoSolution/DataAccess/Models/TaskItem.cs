namespace DataAccess.Models
{
    /// <summary>
    /// يمثل نموذج المهمة.
    /// </summary>
    public class TaskItem
    {
        public int Id { get; set; }
      public string Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}