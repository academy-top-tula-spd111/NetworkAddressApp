using System.Net;
using System.Net.NetworkInformation;

IPAddress local = new IPAddress(new byte[] { 127, 0, 0, 1 });
Console.WriteLine(local);
local = new IPAddress(0x010020FA);
Console.WriteLine(local);

local = IPAddress.Parse("127.0.0.1");

Console.WriteLine(IPAddress.TryParse("127.0.0.1", out local));
local = IPAddress.Loopback;
Console.WriteLine(local);
local = IPAddress.Any;
Console.WriteLine(local);
local = IPAddress.Broadcast;
Console.WriteLine(local);
local = IPAddress.Loopback;
Console.WriteLine(local.AddressFamily);

IPEndPoint endPoint = new IPEndPoint(local, 8080);
Console.WriteLine(endPoint);

UriBuilder builder = new UriBuilder("https", "yandex.ru", 8080, "about/us");
Uri uriYandex =  builder.Uri;
Console.WriteLine(uriYandex);

builder = new UriBuilder();
builder.Scheme = "https";
builder.Port = 3000;
builder.Path = "tv/star";
builder.Host = "rambler.ru";
builder.Query = "name=Max&age=34";
builder.Fragment = "about";
Uri uri = builder.Uri;
Console.WriteLine(uri);

var host = Dns.GetHostEntry("yandex.ru");
Console.WriteLine(host.HostName);
foreach (var ip in host.AddressList)
{
    Console.WriteLine(ip);
}
Console.WriteLine();

var ipYandex = Dns.GetHostAddresses("yandex.ru");
foreach (var ip in ipYandex)
{
    Console.WriteLine(ip);
}

var adapters = NetworkInterface.GetAllNetworkInterfaces();
foreach (var adapter in adapters)
{
    Console.WriteLine();
    Console.WriteLine($"Id:\t\t\t{adapter.Id}");
    Console.WriteLine($"Description:\t\t\t{adapter.Description}");
    Console.WriteLine($"Name:\t\t\t{adapter.Name}");
    Console.WriteLine($"Type:\t\t\t{adapter.NetworkInterfaceType}");
    Console.WriteLine($"MAC:\t\t\t{adapter.GetPhysicalAddress()}");
    Console.WriteLine($"Status:\t\t\t{adapter.OperationalStatus}");
    Console.WriteLine($"Speed:\t\t\t{adapter.Speed}");

    var stats = adapter.GetIPStatistics();
    Console.WriteLine($"Received:\t\t\t{stats.BytesReceived}");
    Console.WriteLine($"Sented:\t\t\t{stats.BytesSent}");
}

Console.WriteLine();

