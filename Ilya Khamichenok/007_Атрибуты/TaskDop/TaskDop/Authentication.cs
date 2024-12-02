using System.Reflection;

namespace TaskDop
{
    public static class Authentication
    {
        public static bool TryAccess(object obj, Access access)
        {
            var type = obj.GetType();
            var attribute = type.GetCustomAttribute<AccessLevelAttribute>();

            if (attribute != null && attribute.Access == access)
            {
                return true;
            }

            return false;
        }
    }
}
