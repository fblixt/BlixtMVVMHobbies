using BlixtMVVMHobbies.Models;

namespace BlixtMVVMHobbies.ViewModels
{
    class HobbyItemViewModel : ViewModelBase
    {
        private readonly Hobby _model;

        public HobbyItemViewModel(Hobby model)
        {
            _model = model;
        }

        public string Name
        {
            get { return _model.Name; }
            set { _model.Name = value; RaisePropertyChanged(); }
        }
        public string Category
        {
            get { return _model.Category; }
            set { _model.Category = value; RaisePropertyChanged(); }
        }
        public string SkillLevel
        {
            get { return _model.SkillLevel; }
            set { _model.SkillLevel = value; RaisePropertyChanged(); }
        }
        public int NumberOfPractitioners
        {
            get { return _model.NumberOfPractitioners; }
            set { _model.NumberOfPractitioners = value; RaisePropertyChanged(); }
        }
    }
}
