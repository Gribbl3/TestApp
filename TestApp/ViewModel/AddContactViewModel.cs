using System.Windows.Input;

namespace TestApp.ViewModel
{
    public class AddContactViewModel : BaseViewModel
    {
        public Model.Contact Contact { get; set; } = new();
        public ICommand SubmitCommand => new Command(Submit);
        public ICommand ResetCommand => new Command(ResetForm);

        private void Submit()
        {
            if (ValidateForm())
            {

            }
        }
        private bool ValidateForm()
        {
            if (!IsFieldEmpty(Contact.Id, "Contact Id") || !IsFieldEmpty(Contact.FirstName, "First Name") || !IsFieldEmpty(Contact.LastName, "Last Name") ||
                !IsFieldEmpty(Contact.Email, "Email"))
            {
                return false;
            }

            if (!IsMinLength((Contact.Id), 5, "Id") || !IsMinLength((Contact.MobileNumber), 11, "Mobile Number"))
            {
                return false;
            }

            string defaultValue = "--SELECT--";
            if (!IsDefaultValue(Contact.SchoolProgram, defaultValue, "School Program") || !IsDefaultValue(Contact.Course, defaultValue, "Course"))
            {
                return false;
            }

            return true;
        }


        private void ResetForm(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
