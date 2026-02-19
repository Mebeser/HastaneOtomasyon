using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Service;




var builder = WebApplication.CreateBuilder(args);

// Dependency Injection LifeCycle 

// AddSingleton() : Uygulama boyunca Tek 1 nesne üretir.
// AddScopped() : Uygulama boyunca Tek 1 nesne üretir. İlgili istek response a döenene kadar bellekte kalır.
// AddTransient() : Her istek geldiğinde 1 nesne üretir. 




builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<MedicalRecordService>();
builder.Services.AddScoped<MedicineService>();
builder.Services.AddScoped<PrescriptionService>();
builder.Services.AddScoped<PrescriptionItemService>();
builder.Services.AddScoped<BillingService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();