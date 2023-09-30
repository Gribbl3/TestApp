using System.Windows.Input;
using TestApp.Model;

namespace TestApp.ViewModel
{
    public class StudentViewModel
    {
        public Student Student { get; set; } = new Student();
        public ICommand Submit { get; set; }
        public ICommand Reset { get; set; }

        public StudentViewModel()
        {
            Submit = new Command(OnSubmitClicked);
            Reset = new Command(OnResetClicked);
        }

        private void OnSubmitClicked()
        {
            Submit.Execute(this);
        }

        private void OnResetClicked()
        {

        }
    }
}
