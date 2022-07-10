using Microsoft.AspNetCore.Components.Forms;

namespace ThirdPartyApiInteraction.Models;

public class ExampleFormModel
{
    public IBrowserFile ExampleFile { get; set; } = default!;
}