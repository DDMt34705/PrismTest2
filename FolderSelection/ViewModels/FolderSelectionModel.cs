using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using DialogService;

namespace FolderSelection.ViewModels
{
    public class FolderSelectionViewModel : BindableBase
    {
        private string _selectedFolder = @"c:\develop\bin";
        public string SelectedFolder
        {
            get { return _selectedFolder; }
            set { SetProperty(ref _selectedFolder, value); }
        }

        private IEventAggregator _eventAggregator;
        private ISelectFolderService _selectFolderService;
        public FolderSelectionViewModel(IEventAggregator eventAggregator, ISelectFolderService selectFolderService)
        {
            _eventAggregator = eventAggregator;
            _selectFolderService = selectFolderService;
            _cmd = new DelegateCommand(SelectFolder);
        }

        private void SelectFolder()
        {
            SelectedFolder = _selectFolderService.SelectFolder();
        }

        private DelegateCommand _cmd;
        public DelegateCommand Cmd { get { return _cmd; } }
    }
}
