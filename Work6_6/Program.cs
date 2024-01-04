using System;
using System.Text.RegularExpressions;

namespace Work6_6
{
    class Program
    {
        private Menu menu;
        private Employees employees;
        
        public static void Main(string[] args)
        {
            Program task = new Program();
        }

        public Program()
        {
            Menu.onAddNewEmployee += AddNewEmployee;
            Menu.onShowAllEmployee += ShowAllEmployees;
            
            employees = new Employees();
            menu = new Menu();
            menu.ShowMenu();
        }

        ~Program()
        {
            if (Menu.onAddNewEmployee != null) Menu.onAddNewEmployee -= AddNewEmployee;
            if (Menu.onShowAllEmployee != null) Menu.onShowAllEmployee -= ShowAllEmployees;
        }

        private void AddNewEmployee(bool isDefault)
        {
            if (isDefault)
            {
                employees.AddDefaultEmployee();                
            }
            else
            {
                employees.AddNewEmployee();                
            }
        }

        private void ShowAllEmployees()
        {
            employees.ShowAllEmployees();
        }
    }

    class Menu
    {
        public static Action<bool> onAddNewEmployee;
        public static Action onShowAllEmployee;
        
        public void ShowMenu()
        {
            Console.Write("1 - add new employee\n2 - Show all employees\n3 - add default employee\n");
            ConsoleKeyInfo key = Console.ReadKey();
            
            Console.WriteLine(">>"+key.KeyChar);

            switch (key.KeyChar)
            {
                case '1':
                    onAddNewEmployee(false);
                    break;
                case '2':
                    onShowAllEmployee();
                    break;
                case '3':
                    onAddNewEmployee(true);
                    break;
            }
            
            ShowMenu();
        }
    }
}