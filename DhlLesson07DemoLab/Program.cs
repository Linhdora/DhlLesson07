var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (value, field) => $"Giá trị '{value}' không hợp lệ cho trường {field}");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        field => $"Trường {field} phải là số");
    options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
        field => $"Vui lòng nhập {field}");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
        value => $"Giá trị '{value}' không hợp lệ");
});