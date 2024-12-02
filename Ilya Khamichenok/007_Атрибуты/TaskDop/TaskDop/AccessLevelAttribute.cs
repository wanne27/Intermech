namespace TaskDop
{
    public class AccessLevelAttribute : Attribute
    {
        private int _access;
        public int Access
        {
            get
            {
                return _access;
            }
        }

        public AccessLevelAttribute(int access)
        {
            _access = access;
        }
    }
}
