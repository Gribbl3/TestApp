namespace TestApp.ViewModel
{
    public class BaseViewModel
    {
        //entries validation
        public static bool IsFieldEmpty(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} is required", "Ok");
                return true;
            }
            return false;
        }

        //id and password validation
        public static bool IsMinLength(string value, int minLength, string fieldName)
        {
            if (value.Length < minLength)
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} must be at least {minLength} characters", "Ok");
                return false;
            }
            return true;
        }

        //pickers validation
        public static bool IsDefaultValue(string value, string defaultValue, string fieldName)
        {
            if (value == defaultValue || value == null)
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} is required", "Ok");
                return false;
            }
            return true;
        }
    }
}
