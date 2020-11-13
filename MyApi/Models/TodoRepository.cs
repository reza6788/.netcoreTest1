using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyApi.Models
{
    public class TodoRepository :ITodoRepository
    {
        private static ConcurrentDictionary<string,TodoItem> _todos=new ConcurrentDictionary<string, TodoItem>();
        public TodoRepository( )
        {
            Add(new TodoItem{Name = "Item1"});
        }
        public void Add(TodoItem todoItem)
        {
            todoItem.Key = Guid.NewGuid().ToString();
            _todos[todoItem.Key] = todoItem;
        }

        public void Update(TodoItem todoItem)
        {
            _todos[todoItem.Key] = todoItem;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }
    }
}
