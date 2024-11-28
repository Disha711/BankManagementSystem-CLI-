using System;

public class BankManagementSystem
{
    // Define a class for Customer Account
    class CustomerAccount
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
    }

    static CustomerAccount[] customerAccounts = new CustomerAccount[10]; // Array to store customer accounts
    static int customerCount = 0; // To keep track of number of customers added

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Bank Management System");
            Console.WriteLine("1. Banker");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    BankerMenu();
                    break;
                case 2:
                    CustomerMenu();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void BankerMenu()
    {
        while (true)
        {
            Console.WriteLine("\nBanker Menu:");
            Console.WriteLine("1. Create Customer Account");
            Console.WriteLine("2. Display All Customer Accounts");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");
            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateCustomerAccount();
                    break;
                case 2:
                    DisplayAllCustomerAccounts();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void CreateCustomerAccount()
    {
        Console.WriteLine("\nCreating Customer Account:");
        CustomerAccount customer = new CustomerAccount();

        Console.Write("Enter Name: ");
        customer.Name = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        customer.AccountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter Password: ");
        customer.Password = Console.ReadLine();

        Console.Write("Enter Account Type: ");
        customer.AccountType = Console.ReadLine();

        customerAccounts[customerCount++] = customer; // Add customer to the array
        Console.WriteLine("Customer Account created successfully.");
    }

    // Method to display all customer accounts
    static void DisplayAllCustomerAccounts()
    {
        Console.WriteLine("\nAll Customer Accounts:");
        if (customerCount == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        for (int i = 0; i < customerCount; i++)
        {
            Console.WriteLine("Name: {0}, Account Number: {1}, Account Type: {2}",customerAccounts[i].Name, customerAccounts[i].AccountNumber, customerAccounts[i].AccountType);
        }
    }

    // Method to handle Customer menu
    static void CustomerMenu()
    {
        Console.WriteLine("\nCustomer Login:");
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        // Check if account exists
        CustomerAccount customer = FindCustomer(accountNumber, password);
        if (customer == null)
        {
            Console.WriteLine("Invalid Account Number or Password.");
            return;
        }

        // Customer operations menu
        while (true)
        {
            Console.WriteLine("\nWelcome, {0}!",customer.Name);
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount to withdraw: ");
                    double amountWithdraw = double.Parse(Console.ReadLine());
                    if (amountWithdraw > customer.Balance)
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                    else
                    {
                        customer.Balance -= amountWithdraw;
                        Console.WriteLine("Amount {0} withdrawn successfully.",amountWithdraw);
                    }
                    break;
                case 2:
                    Console.Write("Enter amount to deposit: ");
                    double amountDeposit = double.Parse(Console.ReadLine());
                    customer.Balance += amountDeposit;
                    Console.WriteLine("Amount {0} deposited successfully.",amountDeposit);
                    break;
                case 3:
                    Console.WriteLine("Your current balance is: {0}",customer.Balance);
                    break;
                case 4:
                    Console.WriteLine("Exiting customer menu.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    // Method to find a customer by account number and password
    static CustomerAccount FindCustomer(int accountNumber, string password)
    {
        foreach (var customer in customerAccounts)
        {
            if (customer != null && customer.AccountNumber == accountNumber && customer.Password == password)
            {
                return customer;
            }
        }
        return null;
    }
}
