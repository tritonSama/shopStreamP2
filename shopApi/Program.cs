using shopBL;
using shopDL;
using shopModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<iRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(builder.Configuration.GetConnectionString("Joshua Henry")));
builder.Services.AddScoped<iCustomerBL, CustomerBL>();
builder.Services.AddScoped<iRepository<CustomerItemJoin>, SQLCustItemJoinRepo>(repo => new SQLCustItemJoinRepo(builder.Configuration.GetConnectionString("Joshua Henry")));
builder.Services.AddScoped<iCustItemJoinBL, CustItemJoinBL>();
builder.Services.AddScoped<iRepository<Item>, SQLItemRepository>(repo => new SQLItemRepository(builder.Configuration.GetConnectionString("Joshua Henry")));
builder.Services.AddScoped<iItemBL, ItemBL>();

var app = builder.Build();

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
