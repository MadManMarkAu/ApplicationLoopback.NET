using ApplicationLoopback.NET;
using System.Runtime.InteropServices;

var callback = (AudioCallback)OnData;
var stopped = (AudioEvent)OnStopped;

var capture = Native.InitializeCapture(2, 48000, 16, callback, stopped);
Console.WriteLine($"Created capture: {capture}");

var startResult = Native.StartCaptureAsync(capture, 41912, true);

Console.WriteLine(startResult);
Console.ReadLine();
Console.WriteLine("Stopping");

Native.StopCaptureAsync(capture);

Console.ReadLine();

Native.FreeCapture(capture);

static void OnData(IntPtr instance, IntPtr data, uint length)
{
    Console.WriteLine($"Got data: {length}");
}

static void OnStopped(IntPtr instance)
{
    Console.WriteLine("Audio capture stopped");
}