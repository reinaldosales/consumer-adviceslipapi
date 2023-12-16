using System.Text.Json;
using Consumer.AdviceSlip.Models;
using Consumer.AdviceSlip.Models.Enum;
using Newtonsoft.Json;
using RestSharp;
using WorkerServicePlusEFCore.Services;

namespace Consumer.AdviceSlip;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    public readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(1000, stoppingToken);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                string baseUrl = _configuration.GetValue<string>("Configurations:AdviceSlip:Url");
                string url = $"{baseUrl}/{AdviceSlipMethod.advice}";

                var client = new RestClient();
                var request = new RestRequest(url, Method.Get);

                var response = await client.GetAsync(request, stoppingToken);

                var slipResponse = JsonConvert.DeserializeObject<SlipResponse>(response.Content);

                Slip slip = new(){
                    Advice = slipResponse.Slip.Advice,
                    AdviceSlipId = slipResponse.Slip.Id
                };

                DbHelper dbHelper = new();
                
                var advice = dbHelper.GetAdviceById(slip.AdviceSlipId);

                if(advice is null)
                    dbHelper.SaveSlip(slip);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message", ex);
                Environment.Exit(1);
            }
        }
    }
}
