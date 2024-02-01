using KBS.CreditAppSys.Application.Extensions;
using KBS.CreditAppSys.Persistence.Extensions;
using KBS.Integration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region My service registration

builder.Services.AddCreditDbContext(builder.Configuration, "CreditConnectionString");
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddIntegrationServices();

#endregion

var app = builder.Build();
app.Services.MigrateCreditDbContext();
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
