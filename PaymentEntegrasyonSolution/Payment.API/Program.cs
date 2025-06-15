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
builder.Services.AddScoped<IFirestoreClient, FirestoreClient>();
builder.Services.AddScoped<IFirestoreRepository, FirestoreRepository>();
builder.Services.AddScoped<IPaymentGateway, IyzicoAdapter>();



var credentialPath = Path.Combine(Directory.GetCurrentDirectory(), "firebase-key.json");
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

builder.Services.AddSingleton(provider =>
{
    var firestoreDb = FirestoreDb.Create("paymentapi-944a7");
    return firestoreDb;
});


var app = builder.Build();
app.Use(async (context, next) =>
{
    context.Items["UserId"] = "1"; // test deðeri
    await next();
});
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
