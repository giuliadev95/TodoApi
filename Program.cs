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

// Get all the tasks
app.MapGet("/todoitems", async (TodoDb db) =>
await db.Todos.ToListAsync());

// Get completed tasks, with a flag 'iscomplete'
app.MapGet("todoitems/complete", async (TodoDb db) =>
await db.Todos.Where(t => t.IsComplete).ToListAsync());

// Get a task by ID
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
    is Todo todo
    ? Results.Ok(todo)
    : Results.NotFound());

app.MapPost("/todoitems", async (Todo toto, TodoDb db) =>
{

}
)


