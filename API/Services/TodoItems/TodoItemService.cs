using API.DTOs;
using Domain.Interfaces;
using Domain.TodoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.TodoItems
{
    public class TodoItemService : BaseService
    {
        public TodoItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AddTodoItemResponse> AddNewAsync(AddTodoItemRequest model)
        {
            // You can you some mapping tools as such as AutoMapper
            var todoItem = new TodoItem(model.Name
                , model.Secret);

            var repository = UnitOfWork.AsyncRepository<TodoItem>();
            await repository.AddAsync(todoItem);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddTodoItemResponse()
            {
                Id = todoItem.Id,
                Name = todoItem.Name
            };

            return response;
        }

        public async Task<List<GetTodoItemListResponse>> SearchAsync(GetTodoItemListRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<TodoItem>();
            var todoItems = await repository
                .ListAsync(_ => _.Name.Contains(request.Search));

            var userDTOs = todoItems.Select(_ => new GetTodoItemListResponse()
            {
                Name=_.Name,
                Secret=_.Secret
            })
            .ToList();

            return userDTOs;
        }

        public async Task<UpdateTodoItemResponse> UpdateAsync(UpdateTodoItemRequest model)
        {
            var repository = UnitOfWork.AsyncRepository<TodoItem>();
            var todoItem = await repository.GetAsync(_ => _.Id == model.Id);
            if (todoItem != null)
            {
                todoItem.Name = model.Name;
                todoItem.Secret = model.Secret;
                

                await repository.UpdateAsync(todoItem);
                await UnitOfWork.SaveChangesAsync();

                return new UpdateTodoItemResponse()
                {
                    Id = todoItem.Id,
                    Name = todoItem.Name
                };
            }

            throw new Exception("User not found.");
        }
    }
}
