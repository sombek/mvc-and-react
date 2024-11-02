using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mvc_and_react.Pages;

public class ReactAppModel : PageModel
{
    public string? JsFileName { get; set; }
    public void OnGet()
    {
        var manifestFilePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "react-app",
            "manifest.json"
        );

        // read the manifest file
        using StreamReader reader = new(manifestFilePath);
        var json = reader.ReadToEnd();
        if (string.IsNullOrEmpty(json)) return;

        var manifestData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(json);
        var data = manifestData?["index.html"]["file"];
        JsFileName = data?.ToString();
    }
}