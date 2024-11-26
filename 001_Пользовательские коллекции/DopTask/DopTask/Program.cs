var a = new Dop();
int[] num = { 1, 2, 3, 4, 5, 6, 7, 7, 7 };

foreach (var n in a.GetNumb(num))
{
    Console.WriteLine(n);
}

class Dop
{
    public IEnumerable<int> GetNumb(int[] num)
    {
        for (int i = 0; i <= num.Length; i++)
        {
            if (i == num.Length)
            {
                yield break;
            }
            else if (num[i] % 2 == 1)
            {
                yield return num[i] * num[i];
            }
        }
    }
}