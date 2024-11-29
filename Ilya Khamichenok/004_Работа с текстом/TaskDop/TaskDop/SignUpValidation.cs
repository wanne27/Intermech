using System.Text.RegularExpressions;

namespace TaskDop
{
    public static class SignUpValidation
    {
        private static string loginPattern = @"^[a-zA-Z]+$";
        private static string passwordPattern = @"^(?=.*\d)(?=.*[a-zA-Z])(?!.*\s).*$";

        public static bool ValidateLogin(string login)
        {
            return Regex.IsMatch(login, loginPattern);
        }

        public static bool VerifyPassword(string password)
        {
            return Regex.IsMatch(password, passwordPattern);
        }
    }
}
