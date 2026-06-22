using Microsoft.EntityFrameworkCore;
using Blog.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddAuthentication();           
builder.Services.AddAuthorization();
builder.Services.AddSignalR();                      



var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();




app.Run();
