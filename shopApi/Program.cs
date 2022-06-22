using shopBL;
using shopDL;
using shopModel;

var builder = WebApplication.CreateBuilder(args);

// Adding CORS to allow all origins to have access to our backend
builder.Services.AddCors(
    (options) => {
        //We configured our CORS to allow anyone to do anything with our backend
        options.AddDefaultPolicy(origin => {
            origin.AllowAnyOrigin(); //Allows any origin to talk to our backend
            origin.AllowAnyMethod(); //Allows any http verb request in our backend
            origin.AllowAnyHeader(); //Allows any http headers to have access to my backend
        });
    }
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<iRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iCustomerBL, CustomerBL>();
builder.Services.AddScoped<iRepository<CustomerItemJoin>, SQLCustItemJoinRepo>(repo => new SQLCustItemJoinRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iCustItemJoinBL, CustItemJoinBL>();
builder.Services.AddScoped<iRepository<Item>, SQLItemRepository>(repo => new SQLItemRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<iItemBL, ItemBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
