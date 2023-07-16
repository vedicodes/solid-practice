namespace SolidConsoleApp
{
    public class BeforePersonDetails // Two responsibilites: Hold data, print that data
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public void PrintReport()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Id: {0}", Id);
        }
    }

    public class AfterPersonDetails // Single responsibility: Hold data 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }

    public class Printer // Single responsibility: Print data
    {
        public void PrintPersonDetails(AfterPersonDetails person)
        {
            Console.WriteLine("Name: {0}", person.Name);
            Console.WriteLine("Age: {0}", person.Age);
            Console.WriteLine("Id: {0}", person.Id);
        }
    }

    public class SingleResponsibility
    {
        public static void Run()
        {
            var printer = new Printer();
            var person = new AfterPersonDetails
            {
                Name = "Person 1",
                Age = 20,
                Id = "IVBWE2e4"
            };
            printer.PrintPersonDetails(person);
        }
    }
}
