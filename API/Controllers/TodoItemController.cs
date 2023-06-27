using API.DTOs;
using API.Services.TodoItems;
using Domain.TodoItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using NLog;

namespace API.Controllers
{
    [ApiController]
    [Route("todoItems")]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoItemService _service;
        private readonly ILogger<TodoItemController> _logger;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public TodoItemController(ILogger<TodoItemController> logger
            , TodoItemService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTodoItemListRequest request)
        {
            try
            {
                var todoItems = await _service.SearchAsync(request);
                return Ok(todoItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                logger.Error(ex);
            }

            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTodoItemRequest request)
        {
            try
            {
                var todoItem = await _service.AddNewAsync(request);
                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                logger.Error(ex);
            }
            return Ok();
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTodoItemRequest request)
        {
            try 
            {
                var todoItem = await _service.UpdateAsync(request);
                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                logger.Error(ex);
            }
            return Ok();
        }

    }
}
