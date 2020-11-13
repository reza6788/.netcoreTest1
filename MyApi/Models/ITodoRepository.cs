using System.Collections.Generic;

namespace MyApi.Models
{
    public interface ITodoRepository
    {
        void Add(TodoItem todoItem);
        void Update(TodoItem todoItem);
        TodoItem Find(string key);
        TodoItem Remove(string key);
        IEnumerable<TodoItem> GetAll();
    }
}
