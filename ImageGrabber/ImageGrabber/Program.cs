using ImageGrabber.Http;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Camera IP address: ");
        var ipAddr = Console.ReadLine();

        Console.WriteLine("Pick an Option\n" +
                          "1.Get Cameras Model\n" +
                          "2.Trigger Cameras Relay\n" +
                          "3.Retreive an image");
        var endPointrequest = Console.ReadLine();

        var getit = new HttpStuff(endPointrequest,ipAddr);

        Task<String> task =  getit.Grabit();

        string result = task.Result;

        Console.WriteLine($"{task.Result}");
        Console.ReadLine(); 
    }
}