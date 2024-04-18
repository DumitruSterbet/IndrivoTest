using IndrivoTest.Helpers;


var builder = WebApplication.CreateBuilder(args);
// Register services using Unity container
UnityConfig.InitializeContainer();
// Add services to the container.
builder.Services.AddControllers(options =>
{
    // Suppress implicit required attribute for non-nullable reference types
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
