

using System;
using System.Linq;
using System.Threading.Tasks;
using G3SDK;

class Program
{
    static async Task Main(string[] args)
    {
        var browser = new G3Browser();
        var devices = await browser.ProbeForDevices();

        var g3 = devices.FirstOrDefault();
        if (g3 == null)
        {
            Console.WriteLine("No Tobii Glasses 3 detected.");
            return;
        }

        Console.WriteLine("Skipping calibration (assumed to be done via GUI).");

        try
        {
            Console.WriteLine("Starting recording...");
            await g3.Recorder.Start();

            await Task.Delay(TimeSpan.FromSeconds(10));

            await g3.Recorder.Stop();
            Console.WriteLine("Recording finalized.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during recording: {ex.Message}");
        }
    }
}
