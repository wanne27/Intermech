namespace TaskDop
{
    public class AccessLevelAttribute : Attribute
    {
        private Access _access;
        public Access Access
        {
            get
            {
                return _access;
            }
        }

        public AccessLevelAttribute(Access access)
        {
            _access = access;
        }
    }
}
