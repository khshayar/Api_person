using NLog;
using NLog.Web;
using RestApi.Filters;
using RestApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.GetCurrentClassLogger();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<EfDataContext>(option=>option
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<LogDbContext>(option=>option
    .UseSqlServer(builder.Configuration.GetConnectionString("LogConnection")));
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<PersonnelService, PersonnelAppService>();
builder.Services.AddScoped<PersonnelRepository, EfPersonnelRepository>();
builder.Services.AddScoped<PersonnelQuery, EfPersonnalQuery>();
builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.AddScoped<IpFilterAttribute>();
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var logDb = scope.ServiceProvider.GetRequiredService<LogDbContext>();
    logDb.Database.Migrate();
    
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<IpFilterMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
