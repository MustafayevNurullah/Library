using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Input;

namespace Library.Command
{
    public class AddFilial : ICommand
    {
        private FilialViewModel filialViewModel { get; set; }
        public AddFilial (FilialViewModel FilialViewModel)
        {
            filialViewModel = FilialViewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = filialViewModel.Filials.FirstOrDefault(x => x.Name == filialViewModel.CurrentFilial.Name);
            if(item==null)
            {

            if (filialViewModel.Filials.Count != 0)
            {
                filialViewModel.CurrentFilial.Id = filialViewModel.Filials[filialViewModel.Filials.Count - 1].Id + 1;
            }
            else
            {
                filialViewModel.CurrentFilial.Id = 1;
            }
            filialViewModel.Filials.Add(filialViewModel.CurrentFilial);
            string json = JsonConvert.SerializeObject(filialViewModel.Filials);
            System.IO.File.WriteAllText("Filials.json", json);           
            filialViewModel.CurrentFilial = new FilialEntity();
            filialViewModel.SelectFilial = new FilialEntity();
            }
            
        }
    }
}
