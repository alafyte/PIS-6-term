using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{any}.RNA", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;

    string parmA = request.Query["ParmA"];
    string parmB = request.Query["ParmB"];

    response.ContentType = "text/plain";

    if (parmA != null && parmB != null)
    {
        await response.WriteAsync($"GET-Http-RNA: ParmA = {parmA}, ParmB = {parmB}");
    }
    else
    {
        await response.WriteAsync("Parameters cannot be null");
    }
});

app.MapPost("/{any}.RNA", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;

    string parmA = request.Query["ParmA"];
    string parmB = request.Query["ParmB"];

    response.ContentType = "text/plain";

    if (parmA != null && parmB != null)
    {
        await response.WriteAsync($"POST-Http-RNA: ParmA = {parmA}, ParmB = {parmB}");
    }
    else
    {
        await response.WriteAsync("Parameters cannot be null");
    }
});


app.MapPut("/{any}.RNA", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;

    string parmA = request.Query["ParmA"];
    string parmB = request.Query["ParmB"];

    response.ContentType = "text/plain";

    if (parmA != null && parmB != null)
    {
        await response.WriteAsync($"PUT-Http-RNA: ParmA = {parmA}, ParmB = {parmB}");
    }
    else
    {
        await response.WriteAsync("Parameters cannot be null");
    }
});

app.MapPost("/4", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;

    string firstNum = request.Query["x"];
    string secondNum = request.Query["y"];

    response.ContentType = "text/plain";

    if (firstNum != null && secondNum != null)
    {
        try
        {
            float x = float.Parse(firstNum);
            float y = float.Parse(secondNum);
            float sum = x + y;
            await response.WriteAsync(sum.ToString());
        }
        catch (FormatException)
        {
            await response.WriteAsync("The format is incorrect");
        }
    }
    else
    {
        await response.WriteAsync("Parameters cannot be null");
    }
});

app.Map("/5", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;

    if (request.Method == "GET")
    {
        response.ContentType = "text/html";
        await response.WriteAsync(File.ReadAllText("task5.html"));
    }
    else if (request.Method == "POST")
    {
        string firstNum = request.Query["x"];
        string secondNum = request.Query["y"];

        if (firstNum != null && secondNum != null)
        {
            try
            {
                float x = float.Parse(firstNum);
                float y = float.Parse(secondNum);
                float mul = x * y;
                await response.WriteAsync(mul.ToString());
            }
            catch (FormatException)
            {
                await response.WriteAsync("The format is incorrect");
            }

        }
        else
        {
            await response.WriteAsync("Parameters cannot be null");
        }
    }
    else
    {
        response.StatusCode = 405;
        response.ContentType = "text/html";
        await response.WriteAsync("<h2>Incorrect method.</h2>");
    }
});


app.Map("/6", async (context) =>
{
    HttpResponse response = context.Response;
    HttpRequest request = context.Request;
    response.ContentType = "text/html";

    if (request.Method == "GET")
    {
        await response.WriteAsync(File.ReadAllText("task6.html"));
    }
    else if (request.Method == "POST")
    {

        string firstNum = request.Form["x"];
        string secondNum = request.Form["y"];

        if (firstNum != null && secondNum != null)
        {
            try
            {
                float x = float.Parse(firstNum);
                float y = float.Parse(secondNum);
                float mul = x * y;
                await response.WriteAsync($"<h2>Result is {mul}</h2>");
            }
            catch (FormatException)
            {
                await response.WriteAsync("The format is incorrect");
            }
        }
        else
        {
            await response.WriteAsync("Parameters cannot be null");
        }
    }
    else
    {
        response.StatusCode = 405;
        await response.WriteAsync("<h2>Incorrect method.</h2>");
    }
});

app.Run();
