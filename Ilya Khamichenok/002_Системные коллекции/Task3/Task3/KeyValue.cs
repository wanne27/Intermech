namespace Task3
{
    public class KeyValue
    {
        public int Key {  get; set; }
        public double Value { get; set; }

        public KeyValue(int key, double value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return "[" + Key + " , " + Value + "]";
        }
    }
}
