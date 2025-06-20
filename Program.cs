/*
 * var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "I'm the GET ethod response in your browser!");

app.Run();

*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/todoitems", async (TodoDb db) =>
await db.Todos.TodoListAsync());


