using System.ComponentModel.DataAnnotations;

namespace TODO_API.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string? ToDoName { get; set; }

    }
}
