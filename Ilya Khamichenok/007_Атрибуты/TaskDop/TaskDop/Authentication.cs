namespace TaskDop
{
    public static class Authentication
    {
        public static bool TryAccess(object obj, Access access)
        {
            var type = obj.GetType();
            var attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes) 
            {
                if (attribute is AccessLevelAttribute accessLevel && accessLevel.Access == access) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}
