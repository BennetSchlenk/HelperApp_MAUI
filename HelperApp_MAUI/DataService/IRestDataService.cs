using HelperApp_MAUI.Models;


namespace HelperApp_MAUI.DataService
{
    public interface IRestDataService
    {
        Task<List<ToDo>> GetAllToDosAsync();

        Task AddToDoAsync(ToDo toDo);

        Task UpdateToDoAsync(ToDo toDo);

        Task DeleteToDoAsync(int id);
    }
}
