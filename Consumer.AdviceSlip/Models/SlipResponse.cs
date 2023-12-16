using System.Text.Json.Serialization;

namespace Consumer.AdviceSlip.Models;

public class SlipResponse
{
    public Slip Slip { get; set; }
}