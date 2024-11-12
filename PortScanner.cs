using System;
using System.Net.Sockets;
using System.Threading.Tasks;

public class PortScanner
{
    public async Task ScanPorts(string ipAddress, int startPort, int endPort)
    {
        for (int port = startPort; port <= endPort; port++)
        {
          await Task.Run(() => CheckPort(ipAddress, port));
        }
    }

    private void CheckPort(string ipAddress, int port)
    {
        using TcpClient client = new TcpClient();
        try
        {
             client.Connect(ipAddress, port);
            Console.WriteLine($"Port {port} is open.");
        }
        catch (SocketException)
        {
            Console.WriteLine($"Port {port} is closed.");
        }
    }
}
