namespace Module3Assignment;
class Program
{
    static void Main(string[] args)
    {
        // ask for input
        Console.WriteLine("Enter 1 to create data file.");
        Console.WriteLine("Enter 2 to parse data.");
        Console.WriteLine("Enter anything else to quit.");
        // input response
        string? resp = Console.ReadLine();
        if (resp == "1")
        {
            // create data file
            // ask a question
            Console.WriteLine("How many weeks of data is needed?");
            // input the response (convert to int)
            int weeks = int.Parse(Console.ReadLine());
            // determine start and end date
            DateTime today = DateTime.Now;
            // we want full weeks sunday - saturday
            DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
            // subtract # of weeks from endDate to get startDate
            DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
            // random number generator
            Random rnd = new Random();
            // create file
            StreamWriter sw = new StreamWriter("data.txt");

            // loop for the desired # of weeks
            while (dataDate < dataEndDate)
            {
                // 7 days in a week
                int[] hours = new int[7];
                for (int i = 0; i < hours.Length; i++)
                {
                    // generate random number of hours slept between 4-12 (inclusive)
                    hours[i] = rnd.Next(4, 13);
                }
                // M/d/yyyy,#|#|#|#|#|#|#
                Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                // add 1 week to date
                dataDate = dataDate.AddDays(7);
            }
            sw.Close();
        }
        else if (resp == "2")
        {
            StreamReader sr = new StreamReader("data.txt");

            while (!sr.EndOfStream)
            {
                string fullLine = sr.ReadLine();
                string[] lineItems = fullLine.Split(',');

                string[] dateItems = lineItems[0].Split('/');
                DateTime startDate = new DateTime(Convert.ToInt32(dateItems[2]), Convert.ToInt32(dateItems[0]), Convert.ToInt32(dateItems[1]));

                Console.WriteLine();
                Console.WriteLine($"Week of {startDate:MMM} {startDate:dd}, {startDate:yyyy}");

                string[] hoursSlept = lineItems[1].Split('|');

                for (int i = 0; i < hoursSlept.Length; i++) {
                    Console.Write($"{hoursSlept[i]} ");
                }

            }
            sr.Close();
        }
    }
}
