using System.Reflection.Metadata;

namespace TaskDop
{
    public class BigData : IDisposable
    {
        private string[] arr = new string[10000000];
        private bool disposed = false;

        int i;
        public BigData()
        {
            for (i = 0; i < 10000000; i++)
            {
                arr[i] = i.ToString("0000000000000000");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    arr = null;
                    Console.WriteLine("Managed resources released.");
                }

                disposed = true;
            }
        }

        ~BigData()
        {
            Dispose(false);         
        }
    }
}
