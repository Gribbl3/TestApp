namespace TestApp.Model
{
    public class Contact : BaseModel
    {
        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }
    }
}
