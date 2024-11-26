using BlixtMVVMHobbies.Command;
using BlixtMVVMHobbies.Models;
using System.Collections.ObjectModel;

namespace BlixtMVVMHobbies.ViewModels
{
    class HobbiesViewModel : ViewModelBase
    {
		private ObservableCollection<HobbyItemViewModel> _hobbies = [];

		public ObservableCollection<HobbyItemViewModel> Hobbies
        {
			get { return _hobbies; }
			set 
            { 
                _hobbies = value; 
                RaisePropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
		}

        private HobbyItemViewModel _selectedHobby;

        public HobbyItemViewModel SelectedHobby
        {
            get { return _selectedHobby; }
            set 
            { 
                _selectedHobby = value; 
                RaisePropertyChanged(); 
                DeleteCommand.RaiseCanExecuteChanged(); 
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public HobbiesViewModel()
        {
            _hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Soccer", Category = "Teamsport", SkillLevel = "Medium", NumberOfPractitioners = 265000000 }));
            _hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Basketball", Category = "Teamsport", SkillLevel = "Medium", NumberOfPractitioners = 454000000 }));
            _hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Floorball", Category = "Teamsport", SkillLevel = "Medium", NumberOfPractitioners = 323000 }));

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

        private void DeleteHobby(object? parameter)
        {
            if(SelectedHobby is not null)
            {
                Hobbies.Remove(SelectedHobby);
                SelectedHobby = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedHobby is not null;

        internal async Task LoadAsync()
        {
            if (Hobbies.Any()) { return; }
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby() { Name = "New hobby" };
            var hobbyIVM = new HobbyItemViewModel(hobby);
            Hobbies.Add(hobbyIVM);
            SelectedHobby = hobbyIVM;
        }
    }
}
