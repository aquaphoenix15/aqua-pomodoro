using NetCoreAudio;

class Program
{
    static int workTime;
    static int breakTime;
    static bool validWorkTimeInput = false;
    static bool validBreakTimeInput = false;

    static async Task Main(String[] args)
    {
        

        do
        {
            Console.Write("How long would you like to work for in minutes?\n> ");
            string userInput = Console.ReadLine();

            validWorkTimeInput = int.TryParse(userInput, out workTime);
            
            if (!validWorkTimeInput)
            {
                Console.WriteLine($"'{userInput}' is not a valid input. Please enter a whole number.");
                Console.ReadLine();
                Console.Clear();
            }

        } while (!validWorkTimeInput);

        

        do
        {
            Console.Write("How long would you like to have a break for in minutes?\n> ");
            String userInput = Console.ReadLine();

            validBreakTimeInput = int.TryParse(userInput, out breakTime);
            
            if(!validBreakTimeInput)
            {
                Console.WriteLine($"'{userInput}' is not a valid input. Please enter a whole number.");
                Console.ReadLine();
                Console.Clear();
            }

        } while (!validBreakTimeInput);

        while (true)
        {
            Console.Write("Press Enter when ready to start a timer for " + workTime + " minute(s).");
            Console.ReadLine();
            await waitTime(workTime);
            playFinishSound();
            Console.Write("Time done. Waiting for input to start break time.");
            Console.ReadLine();
            await waitTime(breakTime);
            playFinishSound();
        }
    }

    private static async Task waitTime(int timeInMinutes)
    {
        Console.WriteLine("Waiting...");
        await Task.Delay(timeInMinutes * 60 * 1000);
    }

    private static void playFinishSound()
    {
        Player player = new Player();
        player.SetVolume(100).Wait();
        player.Play(@"C:\Windows\Media\Alarm05.wav");
        System.Threading.Thread.Sleep(2000);
    }
}