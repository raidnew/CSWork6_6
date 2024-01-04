using System;

namespace Work6_6
{
    public class Employees
    {
        public Employees()
        {
            string lastLine = DataStorage.getInstance().GetLastLine();
            Employee.InitId(lastLine);
        }

        ~Employees()
        {
            
        }

        public void AddDefaultEmployee()
        {
            Employee newEmployee = new Employee("Test test", 18, 170, DateTime.Now.AddYears(-18), "Place Of Birth");
            DataStorage.getInstance().AddEmplpoyee(newEmployee.GetSerializedString());
        }
        public void AddNewEmployee()
        {
            Employee newEmployee = InputNewEmployee();
            DataStorage.getInstance().AddEmplpoyee(newEmployee.GetSerializedString());
        }

        private Employee InputNewEmployee()
        {
            string fullname = "";
            byte age = 0;
            ushort height = 0;
            DateTime dateOfBirth = DateTime.MinValue;
            string placeOfBirth = "";

            bool inputComplete = false;

            void GetData()
            {
                try
                {
                    if (fullname == "")
                    {
                        Console.Write("Input full name: ");
                        fullname = Console.ReadLine();
                    }

                    if (age == 0)
                    {
                        Console.Write("Input age: ");
                        age = Byte.Parse(Console.ReadLine());
                    }

                    if (height == 0)
                    {
                        Console.Write("Input height: ");
                        height = UInt16.Parse(Console.ReadLine());
                    }

                    if (dateOfBirth == DateTime.MinValue)
                    {
                        Console.Write("Input date of birth (dd/mm/yyyy): ");
                        dateOfBirth = DateTime.Parse(Console.ReadLine());
                    }

                    if (placeOfBirth == "")
                    {
                        Console.Write("Input place of birth: ");
                        placeOfBirth = Console.ReadLine();
                    }

                    inputComplete = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid format. Try again.");
                }
            }

            while (!inputComplete)
            {
                GetData();
            }

            return new Employee(fullname, age, height, dateOfBirth, placeOfBirth);
        }
        
        public void ShowAllEmployees()
        {
            int i = 0;
            string testLine = "";
            while (testLine != null)
            {
                testLine = DataStorage.getInstance().GetNextLine();
                if(testLine != null) Console.WriteLine(testLine);
            }

            DataStorage.getInstance().ResetFilePointer();
        }
    }
}