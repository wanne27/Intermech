using System.Collections.Specialized;
try
{
    var purhases = new PurchaseCollection();

    purhases.Add("Ilya", "Producti");
    purhases.Add("Vlad", "Napitki");
    purhases.Add("Vlad", "Producti");
    purhases.Add("Ilya", "Napitki");

    var names = purhases.GetNamesByCategory("Producti");
    var categories = purhases.GetCategoriesByName("Vlad");

    foreach (var name in names)
    {
        Console.WriteLine(name);
    }

    foreach (var category in categories)
    {
        Console.WriteLine(category);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


class PurchaseCollection
{
    NameValueCollection NameToCategoryCollection = new NameValueCollection();

    public void Add(string name, string category)
    {
        NameToCategoryCollection.Add(name, category);
    }

    public string[] GetCategoriesByName(string name)
    {
        var categories = NameToCategoryCollection.GetValues(name);

        if (categories != null)
        {
            return categories;
        }
        else
        {
            throw new ArgumentException("No categories found");
        }
    }

    public IEnumerable<string> GetNamesByCategory(string category)
    {
        foreach (var key in NameToCategoryCollection.AllKeys)
        {
            if (key == null)
            {
                yield break;
            }
            else
            {
                foreach (var categoryByKey in NameToCategoryCollection.GetValues(key))
                {
                    if (categoryByKey != null && categoryByKey == category)
                    {
                        yield return key;
                    }
                }
            }            
        }
    }
}
