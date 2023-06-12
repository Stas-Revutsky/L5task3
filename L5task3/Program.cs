using System.Runtime.Intrinsics.X86;

namespace L5task3
{
    internal class Program
    {
        static int ReadNumber(int start, int end, int i, int count)
        {
            try
            {
                Console.WriteLine($"Enter an integer that is higher then {start} and lower then {end - (count - i) + 1}");
                Console.WriteLine($"You'll have to enter {count - i} more integers");
                int current = Convert.ToInt32(Console.ReadLine());
                if (current + (count - i) <= end && current > start)
                {
                    return current;
                }
                else if (current + (count - i) > end)
                {
                    throw new ApplicationException("Entered int is too high");
                }
                else 
                {
                    throw new ApplicationException("Entered int is too low");
                }
            }
            catch (ApplicationException ex) 
            {
                Console.WriteLine(ex.Message);
                return ReadNumber(start, end, i, count);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return ReadNumber(start, end, i, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ReadNumber(start, end, i, count);
            }
        }
        static void Main()
        {
            int count = 10;
            try
            {
                Console.WriteLine("Enter a starting integer");
                int start = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter an ending integer (greater than or equal to {start + count + 1})");
                int end = Convert.ToInt32(Console.ReadLine());
                if (end - (start + count + 1) < 0)
                {
                    throw new ApplicationException("Range is too small");
                }
                for (int i = 0; i < count; i++)
                {
                    start = ReadNumber(start, end, i, count);
                }
                Console.WriteLine("You are very cool");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
                Main();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Main();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main();
            }
        }
    }
}