using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    class Person
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Email { get; set; }

        [SetsRequiredMembers]
        public Person(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Email: {Email}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string? input;

            Console.WriteLine("=== Person List Input ===");

            do
            {
                string name;
                // Input name, ensure it's not null or empty
                do
                {
                    Console.Write("Enter name: ");
                    name = Console.ReadLine()!;
                } while (string.IsNullOrWhiteSpace(name));

                int age;
                string ageInput;
                // Input age and validate it's a number
                do
                {
                    Console.Write("Enter age: ");
                    ageInput = Console.ReadLine()!;
                } while (!int.TryParse(ageInput, out age));

                string email;
                // Input email, ensure it's not null or empty
                do
                {
                    Console.Write("Enter email: ");
                    email = Console.ReadLine()!;
                } while (string.IsNullOrWhiteSpace(email));

                // Create a new Person using the constructor with required fields
                Person person = new Person(name, age, email);

                people.Add(person);

                // Ask if user wants to add another person
                Console.Write("Do you want to add another person? (y/n): ");
                input = Console.ReadLine();


            } while (input != null && input.ToLower() == "y");

            Console.WriteLine("\n=== List of People ===");

            foreach (var p in people)
            {
                p.Display();
            }

            Console.ReadKey();
        }
    }
}
