using System;
using System.Device.Gpio;
using System.Threading;

const int LED_PIN = 18;
const int PIR_PIN = 23;

using var controller = new GpioController();
controller.OpenPin(LED_PIN, PinMode.Output);
controller.OpenPin(PIR_PIN, PinMode.Input);

controller.RegisterCallbackForPinValueChangedEvent(PIR_PIN, PinEventTypes.Rising, (sender, args) =>
{
    controller.Write(LED_PIN, PinValue.High);
    Console.WriteLine("LED is ON");
});


controller.RegisterCallbackForPinValueChangedEvent(PIR_PIN, PinEventTypes.Falling, (sender, args) =>
{
    controller.Write(LED_PIN, PinValue.Low);
    Console.WriteLine("LED is OFF");
});

Console.WriteLine("Awaiting for user action...");
Console.ReadLine();
controller.Write(LED_PIN, PinValue.Low);
controller.Dispose();