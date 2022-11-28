var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder
    .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithOrigins("http://localhost:8081", "http://localhost", "http://localhost:5004", "http://127.0.0.1:5004", "http://localhost:8080", "http://192.168.0.11:8080");
    //.WithOrigins("http://localhost:8080", "http://192.168.0.11:8080").AllowAnyMethod().AllowAnyHeader();
    //builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
