namespace GroupPreOrderApi
{
    public class DishDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderItemDto
    {
        public DishDto Dish { get; set; }
        public int Quantity { get; set; }
    }
    public class ParticipantSessionDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public bool IsSubmitted { get; set; }

        public List<OrderItemDto> Items {  get; set; }
    }
    public class GroupSessionsResponseDto
    {
        public List<ParticipantSessionDto> Participants { get; set; }
        public decimal Total { get; set; }
    }
}
