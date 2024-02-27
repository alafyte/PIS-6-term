using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseWebSockets();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.Map("/ws", async (context) =>
        {
            WebSocket socket;
            if (context.WebSockets.IsWebSocketRequest)
            {
                socket = await context.WebSockets.AcceptWebSocketAsync();
                await WebSocketRequest(socket);
            }
        });

        app.Run();
    }

    private static async Task WebSocketRequest(WebSocket socket)
    {
        string s = await Receive(socket);
        await Send(socket, s + " " + DateTime.Now.ToString("HH:mm:ss"));
        while (true)
        {
            while (socket.State == WebSocketState.Open)
            {
                Thread.Sleep(2000);
                await Send(socket, DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
    private static async Task<string> Receive(WebSocket socket)
    {
        var buffer = new ArraySegment<byte>(new byte[512]);
        var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
        return Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
    }
    private static async Task Send(WebSocket socket, string s)
    {
        var sendBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Ответ: {s}"));
        await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}