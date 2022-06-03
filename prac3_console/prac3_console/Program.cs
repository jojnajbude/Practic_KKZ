using System;

namespace prac3_console
{
    public abstract class Organization
    {
        private string _name;
        private string _industry;
        private string _area_served;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }
        public string Area_served
        {
            get { return _area_served; }
            set { _area_served = value; }
        }

        public abstract void GetInfo();

        public Organization()
        {
            _name = "No name";
            _industry = null;
            _area_served = null;
        }
        public Organization(string name, string industry, string area_served)
        {
            _name = name;
            _industry = industry;
            _area_served = area_served;
        }

        ~Organization()
        {
            Console.WriteLine("Desposing of" + _name);
        }

    }

    public class Factory : Organization
    {
        private string _head;
        private int _number_of_employees;
        private string _city;

        public string Head
        {
            get { return _head; }
            set { _head = value; }
        }
        public int N_O_E
        {
            get { return _number_of_employees; }
            set { _number_of_employees = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Factory: \n\tName of organisation: {Name}");
            Console.WriteLine("\tName: {0}\n\tHead: {1}\n\tNumber of employees: {2}\n\tCity: {3}\n",
                Name, _head, _number_of_employees, _city);
        }

        public Factory() : base()
        {
            _head = null;
            _number_of_employees = 0;
            _city = null;
        }
        public Factory(string name, string industry, string area_served, string head, string city, int number_of_employees) : base(name, industry, area_served)
        {
            _head = head;
            _city = city;
            _number_of_employees = number_of_employees;
        }
        ~Factory(){}

}

public class Insurance : Organization
{
    private int _client_number;
    private string _speciality;
    public int CN
    {
        get { return _client_number; }
        set { _client_number = value; }
    }
        public string Speciality
    {
        get { return _speciality; }
        set { _speciality = value; }
    }
    public override void GetInfo()
    {
        Console.WriteLine($"Insurance: \n\tName of organisation: {Name}");
        Console.WriteLine("\tNumber of clients: {0}\n\tSpecialization: {1}\n", _client_number, _speciality);
    }

    public Insurance() : base() { }
    public Insurance(string name, string industry, string area_served,
        int client_number, string spec) : base(name, industry, area_served)
    {
        this._client_number = client_number;
        this._speciality = spec;
    }

        ~Insurance() { }


}

public class BuildingCompany : Organization
{
        private string _speciality;
        private string _city;
        private int _number_of_employees;

        public string Speciality { set => _speciality = value; get => _speciality; }
        public string City { set => _city = value; get => _city; }
        public int N_O_E { set => _number_of_employees = value; get => _number_of_employees; }

        public override void GetInfo()
        {
            Console.WriteLine($"Building Company: \n\tName of organisation: {Name}");
            Console.WriteLine("\tName: {0}\n\tSpeciality: {1}\n\tNumber of employees: {2}\n\tCity: {3}\n",
                Name, _speciality, _number_of_employees, _city);
        }

        public BuildingCompany() { }
        public BuildingCompany(string name, string industry, string area_wide, string spec, string city, int n_o_e):base(name, industry, area_wide)
        {

        }

        ~BuildingCompany() { }

    }

internal class Program
{
    static void Main(string[] args)
    {
            Factory f = new Factory("agrr", "oil", "Country", "Popolski", "Kyiv", 900);
            f.GetInfo();

    }
}
}