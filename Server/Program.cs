using Microsoft.EntityFrameworkCore;
using RickServer.Models;
        
ApiCharacter apiC = new ApiCharacter("https://rickandmortyapi.com/api/character/");
ApiEpisode apiE = new ApiEpisode("https://rickandmortyapi.com/api/episode/");


while (!apiC.endPage() && !apiC.DbFull()) {
    await apiC.GetApi();
}

while (!apiE.endPage() && !apiE.DbFull()) {
    await apiE.GetApi();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=myDb.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
