using System.Collections;

var collection = new CitizenCollection
{
    new Worker("Vasya", "BM123567"),
    new Pensioner("Kolya", "BM123567"),
    new Student("Vpiska", "BM33333"),
    new Pensioner("Stepa", "BM323232"),
    new Worker("Ilya1", "BM123567"),
    new Worker("Ilya2", "BM123567")
};

var a = collection.ReturnLast();
collection.RemoveCitizen(new Student("Vpiska", "BM33333"));
collection.RemoveFirst();
collection.RemoveCitizen(a);
collection.Contains(a);

foreach (var item in collection)
{
    Console.WriteLine(item);
}

abstract class Citizen
{
    private int index;

    public string Name { get; }
    public string PassportNumber { get; }
    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    public Citizen(string name, string passportNumber)
    {
        Name = name;
        PassportNumber = passportNumber;
    }

    public override string? ToString()
    {
        if (string.IsNullOrEmpty(Name))
        {
            return base.ToString();
        }

        return $"{Name} Queue number - {index}";
    }

    public override bool Equals(object? obj)
    {
        var person = obj as Citizen;

        if (person == null)
        {
            return false;
        }
        else if (person.Name != Name)
        {
            return false;
        }

        return person.PassportNumber == PassportNumber;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

class Student : Citizen
{

    public Student(string name, string passportNumber) : base(name, passportNumber) { }
}

class Pensioner : Citizen
{
    public Pensioner(string name, string passportNumber) : base(name, passportNumber) { }
}

class Worker : Citizen
{
    public Worker(string name, string passportNumber) : base(name, passportNumber) { }
}

class CitizenCollection : IEnumerable
{
    List<Citizen> citizens = new List<Citizen>();

    public void Add(Citizen citizen)
    {
        if (citizens.Count == 0)
            citizen.Index = 1;

        var person = citizens.Contains(citizen);
        var lastPersone = citizens.LastOrDefault();

        if (!person)
        {
            if (citizen is Pensioner)
            {
                var lastPensioner = citizens.OfType<Pensioner>().LastOrDefault();
                if (lastPensioner != null)
                {
                    citizen.Index = lastPensioner.Index + 1;
                    citizens.Insert(lastPensioner.Index, citizen);
                }
                else
                {
                    citizen.Index = 1;
                    citizens.Insert(0, citizen);
                }

                foreach (var c in citizens)
                {
                    if (!(c is Pensioner))
                    {
                        c.Index += 1;
                    }
                }
            }
            else
            {
                if (lastPersone != null)
                {
                    citizen.Index = lastPersone.Index + 1;
                }

                citizens.Add(citizen);
            }
        }
        else
        {
            Console.WriteLine($"Сitizen {citizen} already exists");
        }

        Console.WriteLine($"Citizen {citizen.Name} is added. Queue number - {citizen.Index}");
    }

    public void RemoveFirst()
    {
        citizens.RemoveAt(0);
    }

    public void RemoveCitizen(Citizen citizen)
    {
        citizens.Remove(citizen);
    }

    public bool Contains(Citizen citizen)
    {
        var person = citizens.Where(c => c.Equals(citizen)).FirstOrDefault();

        if (person != null)
        {
            Console.WriteLine($"Citizen {person.Name} is contained. Queue number - {person.Index}");
            return true;
        }
        else
        {
            Console.WriteLine($"Citizen {citizen.Name} is not contained.");
            return false;
        }
    }

    public Citizen ReturnLast()
    {
        var person = citizens.LastOrDefault();

        if (person != null)
        {
            Console.WriteLine($"Last citizen is {person.Name}. Queue number - {person.Index}");
            return person;
        }
        else
        {
            Console.WriteLine("Queue is empty");
            return null;
        }
    }

    public void Clear()
    {
        citizens.Clear();
    }

    public IEnumerator GetEnumerator()
    {
        return citizens.GetEnumerator();
    }
}