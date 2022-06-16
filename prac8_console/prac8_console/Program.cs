using System;
using System.Collections.Generic;

namespace prac3_console
{
    public interface IInfo
    {
        public void GetInfo();
    }

    public interface IPayday
    {
        public void Pay();
    }

    public abstract class Organization
    {
        public string name;
        public string industry;
        public string area_served;

        public Organization(string name, string industry, string area_served)
        {
            this.name = name;
            this.industry = industry;
            this.area_served = area_served;
        }
    }

    public class Factory : Organization, IPayday, IInfo
    {
        public string head;
        public int number_of_employees;
        public string city;

        public void GetInfo()
        {
            Console.WriteLine($"Factory: \n\tName of organisation: {name}");
            Console.WriteLine("\tName: {0}\n\tHead: {1}\n\tNumber of employees: {2}\n\tCity: {3}\n",
                name, head, number_of_employees, city);
        }

        public void Pay()
        {
            Console.WriteLine($"{number_of_employees} employees was paid their salary");
        }

        public Factory(string name, string industry, string area_served, string head, string city, int number_of_employees) : base(name, industry, area_served)
        {
            this.head = head;
            this.city = city;
            this.number_of_employees = number_of_employees;
        }
    }

    public class Insurance : Organization, IInfo
    {
        public int client_number;
        public string speciality;

        public void GetInfo()
        {
            Console.WriteLine($"Insurance: \n\tName of organisation: {name}");
            Console.WriteLine("\tNumber of clients: {0}\n\tSpecialization: {1}\n", client_number, speciality);
        }

        public Insurance(string name, string industry, string area_served, int client_number, string speciality) : base(name, industry, area_served)
        {
            this.client_number = client_number;
            this.speciality = speciality;
        }
    }

    public class BuildingCompany : Organization, IPayday, IInfo
    {
        public string speciality;
        public string city;
        public int number_of_employees;

        public void GetInfo()
        {
            Console.WriteLine($"Building Company: \n\tName of organisation: {name}");
            Console.WriteLine("\tName: {0}\n\tSpeciality: {1}\n\tNumber of employees: {2}\n\tCity: {3}\n",
                name, speciality, number_of_employees, city);
        }

        public void Pay()
        {
            Console.WriteLine($"{number_of_employees} employees was paid their salary");
        }

        public BuildingCompany(string name, string industry, string area_wide, string speciality, string city, int number_of_employees) : base(name, industry, area_wide)
        {
            this.speciality = speciality;
            this.city = city;
            this.number_of_employees = number_of_employees;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(() => Console.WriteLine("Delegate work started\n"));

            Factory f = new Factory("Oil Co.", "oil", "Country", "Popolski", "Kyiv", 900);
            BuildingCompany bc = new BuildingCompany("Building Co.", "skys", "City", "Houses", "Odesa", 1900);
            Insurance ins = new Insurance("Insurance Co. ", "Money", "City", 300, "Cars");

            action += f.Pay;
            action += f.GetInfo;

            action += bc.Pay;
            action += bc.GetInfo;

            action += ins.GetInfo;

            action.Invoke();
        }
    }
}