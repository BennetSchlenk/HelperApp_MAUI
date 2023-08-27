using Microsoft.EntityFrameworkCore;
using TODO_API.Data;
using TODO_API.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));
string SQLConnectionString = builder.Configuration.GetConnectionString("MariaDBConnection")!;

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(SQLConnectionString, ServerVersion.AutoDetect(SQLConnectionString)));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDos.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext context, ToDo toDo) =>
{
    await context.ToDos.AddAsync(toDo);

    await context.SaveChangesAsync();

    return Results.Created($"api/todo/{toDo.Id}", toDo);
});

app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ToDo toDo) =>
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

    if(toDoModel == null) 
    {
        return Results.NotFound();
    }

    toDoModel.ToDoName = toDo.ToDoName;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) => 
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

    if (toDoModel == null)
    {
        return Results.NotFound();
    }

    context.ToDos.Remove(toDoModel);

    await context.SaveChangesAsync();

    return Results.NoContent();

});


app.Run();
