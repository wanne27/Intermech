using System.Collections;

namespace Task3
{
    internal class AccountCollection : IEnumerable
    {
        private List<KeyValue> accounts = new List<KeyValue> ();

        public void Add(int companyAccount, double availableAmount)
        {
            accounts.Add(new KeyValue(companyAccount, availableAmount));
        }

        public List<KeyValue> GetByInt(int account)
        {
            return accounts.Where(a => a.Key == account).ToList();
        }

        public List<KeyValue> GetByDouble(double amount)
        {
            return accounts.Where(a => a.Value == amount).ToList();
        }

        public bool Remove(int companyAccount)
        {
            var account = accounts.Where(a => a.Key == companyAccount).FirstOrDefault();

            if (account != null)
            {
                accounts.Remove(account);
                return true;
            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
           return accounts.GetEnumerator();
        }
    }
}

