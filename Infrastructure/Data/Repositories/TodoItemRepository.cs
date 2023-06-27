using Domain.TodoItems;

namespace Infrastructure.Data.Repositories
{
    public class TodoItemRepository : RepositoryBase<TodoItem>
        , ITodoItemRepository
    {
        public TodoItemRepository(TodoContext dbContext) : base(dbContext)
        {
        }
    }
}
