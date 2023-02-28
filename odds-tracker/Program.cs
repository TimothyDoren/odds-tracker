
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using odds_tracker;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
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


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiRequestController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var client = new HttpClient())
            {
                string apiKey = "ebe6264131b58265f35e4a446a3474e5";
                client.BaseAddress = new Uri("https://api.the-odds-api.com");
                var response = await client.GetAsync("/v4/sports/upcoming/odds/?regions=us&markets=h2h&oddsFormat=american&apiKey=" + apiKey);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<OddsApiResponse>(json);
                // You can parse the result and process it as needed here.
            }

            return Ok();
        }
    }
}