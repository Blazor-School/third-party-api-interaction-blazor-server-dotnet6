using FirstThirdPartyApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FirstThirdPartyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet("[action]")]
    public void ProcessPrimitiveUrlData(string data) => Console.WriteLine($"Data received: {data}.");

    [HttpPost("[action]")]
    public void ProcessComplexData([FromBody] ExampleClass data) => Console.WriteLine($"Data received: {JsonSerializer.Serialize(data)}.");

    [HttpPost("[action]")]
    public void ProcessPrimitiveData([FromBody] string data) => Console.WriteLine($"Data received: {data}.");

    [HttpPost("[action]")]
    public void ProcessStreamdata([FromForm] ExampleStreamClass streamModel) => Console.WriteLine($"Stream received with length: {streamModel.FileStream.Length}");

    [HttpGet("[action]")]
    public IActionResult ReturnPrimitiveData() => Ok("Blazor School");

    [HttpGet("[action]")]
    public IActionResult ReturnComplexData() => Ok(new ExampleClass { ExampleString = "Blazor School" });

    [HttpGet("[action]")]
    public IActionResult ReturnStreamData() => Ok(new FileStream($"{Environment.CurrentDirectory}/SampleFile/logo.png", FileMode.Open));
}
