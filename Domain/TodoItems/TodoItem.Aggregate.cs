using Domain.Base;
using System;
using System.Linq;
using System.Net;

namespace Domain.TodoItems
{
    public partial class TodoItem : IAggregateRoot
    {
        public TodoItem(string name
            , string secret)
        {
            Name = name;
            Secret = secret;
           
        }

        
    }
}
