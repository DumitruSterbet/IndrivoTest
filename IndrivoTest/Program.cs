using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Bussines.Services;
using IndrivoTest.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(options =>
{
    // Suppress implicit required attribute for non-nullable reference types
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the Customs Services to a singleton lifecycle
builder.Services.AddSingleton<ITypeService, TypeService>();
builder.Services.AddSingleton<IEntityService, EntityService>();
UnityConfig.InitializeContainer();
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
