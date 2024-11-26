using System.Collections.Specialized;

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

class PurchaseCollection
{
    NameValueCollection NameToCategoryCollection = new NameValueCollection();
    NameValueCollection CategoryToNameCollection = new NameValueCollection();

    public void Add(string name, string category)
    {
        NameToCategoryCollection.Add(name, category);
        CategoryToNameCollection.Add(category, name);
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

    public string[] GetNamesByCategory(string category)
    {
        var categories = CategoryToNameCollection.GetValues(category);

        if (categories != null)
        {
            return categories;
        }
        else
        {
            throw new ArgumentException("No names found");
        }
    }
}
