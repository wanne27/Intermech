using System.Collections;

var month = new MonthCollection
{
    new Month("December", 31,12),
    new Month("January", 31,1),
    new Month("February", 28,2),
    new Month("March", 31,3),
    new Month("April", 30,4),
    new Month("May", 31,5),
    new Month("June", 30,6),
    new Month("July", 31,7),
    new Month("August", 31,8),
    new Month("September", 30,9),
    new Month("October", 31,10),
    new Month("November", 30,11)
};

foreach (var m in month.GetByDays(30))
{
    Console.WriteLine(m.name);
}

try
{
    Console.WriteLine(month.GetByNumber(12).name);
}
catch
{
    Console.WriteLine("Incorrect month number!");
}


public class Month
{
    public string name;
    public int number;
    public int days;

    public Month(string name, int days, int number)
    {
        this.name = name;
        this.number = number;
        this.days = days;
    }
}

class MonthCollection : IEnumerable
{
    List<Month> months = new List<Month>();

    public void Add(Month month)
    {
        months.Add(month);
    }

    public IEnumerable<Month> GetByDays(int days)
    {
        return months.Where(d => d.days >= days);
    }

    public Month GetByNumber(int number)
    {
        var month = months.FirstOrDefault(n => n.number == number);
        if (month == null)
        {
            throw new Exception();
        }
        else
        {
            return month;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return months.GetEnumerator();
    }
}