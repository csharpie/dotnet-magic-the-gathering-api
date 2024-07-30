var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MagicTheGatheringApi v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
