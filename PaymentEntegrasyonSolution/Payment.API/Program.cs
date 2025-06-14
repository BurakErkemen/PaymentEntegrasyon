using Google.Cloud.Firestore;
using Iyzipay;
using Payment.Repository;
using Payment.Repository.Services;
using Payment.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaymentServices, PaymentService>();
builder.Services.AddScoped<IFirestoreRepository, FirestoreRepository>();
builder.Services.AddScoped<IyzicoAdapter>();



var credentialPath = Path.Combine(Directory.GetCurrentDirectory(), "MyApp.Infrastructure", "Secrets", "firebase-key.json");
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

builder.Services.AddSingleton(provider =>
{
    var firestoreDb = FirestoreDb.Create("project_id");
    return firestoreDb;
});

// Ýyzipay Configuration
Options options = new Options
{
    ApiKey = "ApiKey",
    SecretKey = "SecretKey",
    BaseUrl = "BaseUrl"
};


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
