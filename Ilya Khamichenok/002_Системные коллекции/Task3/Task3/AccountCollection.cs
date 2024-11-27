using System.Collections;

namespace Task3
{
    internal class AccountCollection : IEnumerable
    {
        private List<(int, double)> Accounts = new List<(int, double)> ();

        public void Add(int companyAccount, double availableAmount)
        {
            Accounts.Add((companyAccount, availableAmount));
        }

        public List<(int,double)> GetByInt(int account)
        {
            return Accounts.Where(a => a.Item1 == account).ToList();
        }

        public List<(int, double)> GetByDouble(Double amount)
        {
            return Accounts.Where(a => a.Item2 == amount).ToList();
        }

        public void Remove((int, double) accountAmount)
        {
            Accounts.Remove(accountAmount);
        }

        public IEnumerator GetEnumerator()
        {
           return Accounts.GetEnumerator();
        }
    }
}
