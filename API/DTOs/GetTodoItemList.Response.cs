namespace API.DTOs
{
    public class GetTodoItemListResponse
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
