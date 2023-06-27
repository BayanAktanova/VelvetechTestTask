using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.TodoItems
{
    public partial class TodoItem : BaseEntity<int>
    {
        //public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
