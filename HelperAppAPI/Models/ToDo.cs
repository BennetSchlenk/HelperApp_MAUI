using System.ComponentModel.DataAnnotations;

namespace TODO_API.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string? ToDoName { get; set; }

    }
}
