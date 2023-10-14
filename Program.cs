namespace dotnetLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];
            try
            {
                for (var index = 0; index < 10; index++)
                {
                    Console.WriteLine(arr[index]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Array index out of range.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Text registry failed.");
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.WhenHappened); // Custom exception error message
                Console.WriteLine("Customized Exception.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Oops! Something went wrong.");
            }
            Save("Test");
        }
        static void Save(string text)
        {
            if (string.IsNullOrEmpty(text)) // If text is null or empty, throws DateTime.Now
            {
                throw new MyException(DateTime.Now);
            }
            Console.WriteLine($"Text: {text}");
        }

        public class MyException : Exception
        {
            public MyException(DateTime date)
            {
                WhenHappened = date;
            }
            public DateTime WhenHappened { get; set; }
        }
    }
}