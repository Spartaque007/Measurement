var i = 0;
while (true) {
    Console.WriteLine($"Processor is running {DateTime.Now}");
    Task.Delay(2000).Wait();
    i++;

    if (i == 10)
    {
        Console.Clear();
    }

}