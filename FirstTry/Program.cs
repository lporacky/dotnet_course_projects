public class Program
{
    public static string[] names = new string[10];
    public static double[] prices = new double[10];
    public static int[] stocks = new int[10];
    public static int productCount = 0;

    public static void AddProduct()
    {
        Console.WriteLine("Enter product name:");
        names[productCount] = Console.ReadLine();

        Console.WriteLine("Enter product price:");
        prices[productCount] = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter stock quantity:");
        stocks[productCount] = int.Parse(Console.ReadLine());

        productCount++;
        Console.WriteLine("Product added.");
    }

    public static void ViewProducts()
    {
        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine((i + 1) + ". " + names[i] + 
                " | Price: " + prices[i] + 
                " | Stock: " + stocks[i]);
        }
    }

    public static void UpdateStock()
    {
        Console.WriteLine("Enter product number:");
        int number = int.Parse(Console.ReadLine()) - 1;

        if (number >= 0 && number < productCount)
        {
            Console.WriteLine("Enter new stock quantity:");
            stocks[number] = int.Parse(Console.ReadLine());
            Console.WriteLine("Stock updated.");
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    public static void RemoveProduct()
    {
        Console.WriteLine("Enter product number to remove:");
        int number = int.Parse(Console.ReadLine()) - 1;

        if (number >= 0 && number < productCount)
        {
            for (int i = number; i < productCount - 1; i++)
            {
                names[i] = names[i + 1];
                prices[i] = prices[i + 1];
                stocks[i] = stocks[i + 1];
            }

            productCount--;
            Console.WriteLine("Product removed.");
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. View products");
            Console.WriteLine("3. Update stock");
            Console.WriteLine("4. Remove product");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ViewProducts();
                    break;
                case "3":
                    UpdateStock();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}