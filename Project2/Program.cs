using System.Collections.Generic;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> UsersList = new List<Users>();
            List<Product> ProductsList = new List<Product>();
            string flag = null;
            int index = 0;
            while (flag != "DONE")
            {
                index++;
                Users currUser = new Users();
                currUser.Number = index;
                Console.Write($"Enter the name of user {index}:");
                currUser.Name = Console.ReadLine();
                Console.Write($"Enter the password of user {index}:");
                currUser.Password = Console.ReadLine();
                Console.Write($"Enter the budget of user {index}:");
                currUser.Budget = double.Parse(Console.ReadLine());
                UsersList.Add(currUser);
                Console.Write("Type DONE if there are no more people:");
                flag = Console.ReadLine();
            }
            flag = null;
            index = 0;
            while (flag != "DONE")
            {
                Console.Write("Whats your Username: ");
                string username = Console.ReadLine();
                int indexUser = Users.FindIndex(username, UsersList);
                Console.WriteLine("Do you want to Log in or Log out?");
                string LogFlag = Console.ReadLine();
                switch (LogFlag)
                {
                    case "LogIn":
                        {
                            for (int i = 0; i < UsersList.Count; i++)
                            {
                                if (UsersList[i].Name == username)
                                {
                                    if (UsersList[i].loggedIn)
                                    {
                                        Console.WriteLine("Your already logged in!");
                                    }
                                    else
                                    {
                                        Console.Write("Whats your password:");
                                        string password = Console.ReadLine();
                                        bool passIsRight = false;
                                        while (passIsRight == false)
                                        {
                                            if (UsersList[i].Password == password)
                                            {
                                                Console.WriteLine("You have logged in!");
                                                passIsRight = true;
                                                UsersList[i].loggedIn = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong password!");
                                                Console.Write("Try Again:");
                                                password = Console.ReadLine();
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    case "LogOut":
                        {
                            for (int i = 0; i < UsersList.Count; i++)
                            {
                                if (UsersList[i].Name == username)
                                {
                                    if (UsersList[i].loggedIn)
                                    {
                                        Console.WriteLine("You succsesfully logged out!");
                                        UsersList[i].loggedIn = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your not logged in!");
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
                if (UsersList[indexUser].loggedIn)
                {
                    Console.Write("Do you want to sell a product to the okazion?(Yes/No):");
                    string ProdFlag = Console.ReadLine();
                    if (ProdFlag == "Yes")
                    {
                        Product currProd = new Product();
                        Console.Write($"Enter the number of product:");
                        currProd.Id = int.Parse(Console.ReadLine());
                        Console.Write($"Enter the name of product:");
                        currProd.Name = Console.ReadLine();
                        Console.Write($"Enter the price of product:");
                        currProd.Price = double.Parse(Console.ReadLine());
                        UsersList[indexUser].Budget += currProd.Price;
                        ProductsList.Add(currProd);
                    }
                    else if (ProdFlag == "No")
                    {
                        Console.WriteLine("OK!");
                    }
                    Console.Write("Do you want to buy a product?(Yes/No):");
                    string BuyFlag = Console.ReadLine();
                    if (BuyFlag == "Yes")
                    {
                        Console.WriteLine("Here is what you can buy!!!");
                        for (int i = 0; i < ProductsList.Count; i++)
                        {
                            Console.WriteLine($"Id:{ProductsList[i].Id} , Product:{ProductsList[i].Name} , Price:{ProductsList[i].Price}");
                            Console.Write("Do you want to buy it?(Yes/No):");
                            string confirmFlag = Console.ReadLine();
                            if (confirmFlag == "Yes")
                            {
                                if (UsersList[indexUser].Budget < ProductsList[i].Price)
                                {
                                    Console.WriteLine("You dont have the budget!!!");
                                }
                                else
                                {
                                    UsersList[indexUser].Budget -= ProductsList[i].Price;
                                    Console.WriteLine($"You succsefully bought a {ProductsList[i].Name}!!!");
                                    ProductsList.RemoveAt(i);
                                }
                            }
                            else if (confirmFlag == "No")
                            {
                                Console.WriteLine("OK!");
                            }
                        }
                    }
                    else if (ProdFlag == "No")
                    {
                        Console.WriteLine("OK!");
                    }
                }
                else
                {
                    Console.WriteLine("If you want to buy or sell please Log In!!!");
                }
                Console.Write("Are you finished?(DONE):");
                flag = Console.ReadLine();
            }
        }
    }
}
