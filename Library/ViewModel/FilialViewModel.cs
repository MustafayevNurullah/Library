using Library.Command;
using Library.Entity;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace Library.ViewModel
{
   public class FilialViewModel:BaseViewModel
    {

        public AddFilial addFilial { get; set; }
        public UpdateFilial updateFilial { get; set; }
        public DeleteFilial deleteFilial { get; set; }
        public FilialViewModel()
        {
            
            addFilial = new AddFilial(this);
            updateFilial = new UpdateFilial(this);
            deleteFilial = new DeleteFilial(this);
            CurrentFilial = new FilialEntity();
            SelectFilial = new FilialEntity();
          
        }
        private FilialEntity currentfilial;
        public FilialEntity CurrentFilial
        {
            get
            {
                return currentfilial;
            }
            set
            {
                currentfilial = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentFilial)));
            }
        }
        private FilialEntity selectfilial;
        public FilialEntity SelectFilial
        {
            get
            {
                return selectfilial;
            }
            set
            {
                selectfilial = value;
                if (value != null)
                {
                     CurrentFilial = SelectFilial.FilialClone();
                }
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectFilial)));
            }
        }
        private ObservableCollection<FilialEntity> filials = new ObservableCollection<FilialEntity>();
        public ObservableCollection<FilialEntity> Filials
        {
            get
            {
                return filials;
            }
            set
            {
                //if (File.Exists("Filials.json"))
                //{
                //    string jsonFilial = File.ReadAllText("Filials.json");
                //    this.filials = JsonConvert.DeserializeObject<ObservableCollection<FilialEntity>>(jsonFilial);
                //}
                //else
                //{
                //}
                filials = value;
                OnpropertyChanged(new PropertyChangedEventArgs("Filials"));
            }
        }
    }
}
