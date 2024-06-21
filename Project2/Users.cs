using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Users
    {
        private int number;
        private string name;
        private string password;
        private double budget;
        public bool loggedIn;
        
        public int Number 
        {  
            get { return number; } 
            set {  number = value; } 
        }
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        public string Password 
        { get { return password; } 
            set { password = value; } 
        }
        public double Budget 
        { 
            get {  return budget; } 
            set {  budget = value; } 
        }
        public Users() 
        {
            
        }
        public Users(int number, string name, string password, double budget)
        {
            Number = number;
            Name = name;
            Password = password;
            Budget = budget;
        }
        public static int FindIndex(string username, List<Users> usersList)
        {
            int index = 0;
            for (int i = 0;i<usersList.Count;i++)
            {
                if (usersList[i].Name == username) 
                { 
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
