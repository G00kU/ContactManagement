using ContactMangementServices.Repository;
using ContactMangementServices.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ContactMangementDbContext>(options =>
{
    var connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connnectionString);
}
);

builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
