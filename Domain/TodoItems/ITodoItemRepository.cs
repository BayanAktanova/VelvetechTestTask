using Domain.Interfaces;

namespace Domain.TodoItems
{
    public interface ITodoItemRepository : IAsyncRepository<TodoItem>
    {
    }
}
