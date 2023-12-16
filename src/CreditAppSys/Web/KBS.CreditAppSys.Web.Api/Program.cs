using KBS.CreditAppSys.Persistence.Extensions;
using KBS.CreditAppSys.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddSwaggerGen();

#region My service registration

builder.Services.AddCreditDbContext(builder.Configuration, "CreditConnectionString");
builder.Services.AddPersistenceServices();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
