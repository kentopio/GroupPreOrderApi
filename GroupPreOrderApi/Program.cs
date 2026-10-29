using GroupPreOrderApi;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/guest/groups/{groupReservationId}/sessions", (string groupReservationId) =>
{
    var participants = new List<ParticipantSessionDto>();
    participants.Add(new ParticipantSessionDto
    {
        Id = "session1",
        Type = "Guest",
        Name = "Andrii",
        IsSubmitted = true,
        Items = new List<OrderItemDto>
    {
        new OrderItemDto
        {
            Dish = new DishDto { Id = "dish1", Name = "Caesar Salad", Price = 180 },
            Quantity = 2
        }
    }
    });
    participants.Add(new ParticipantSessionDto
    {
        Id = "session2",
        Type = "Guest",
        Name = "Olena",
        IsSubmitted = false,
        Items = new List<OrderItemDto>
    {
        new OrderItemDto
        {
            Dish = new DishDto { Id = "dish2", Name = "Tom Yum", Price = 220 },
            Quantity = 1
        }
    }
    });
    decimal groupTotal = 0;
    foreach (var p in participants)
    {
        decimal pTotal = 0;
        foreach (var item in p.Items)
        {
            pTotal += (item.Dish.Price * item.Quantity);
        }
        p.Total = pTotal;
        groupTotal += pTotal;
    }
    var response = new GroupSessionsResponseDto
    {
        Participants = participants,
        Total = groupTotal
    };

    return Results.Ok(response);
});
app.Run();
