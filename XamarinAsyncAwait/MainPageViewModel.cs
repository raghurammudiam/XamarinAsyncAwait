using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAsyncAwait
{
    public class MainPageViewModel
    {
        public Command NormalClickCommand { get; }
        public Command AsyncClickCommand { get; }
        public ObservableCollection<string> clickTexts { get; } = new ObservableCollection<string>();

        public MainPageViewModel()
        {
            NormalClickCommand = new Command(() => { clickTexts.Add("Normal button clicked"); });

            //When "Async button" is clicked if this was not an Async method, 
            //the app will not let you click "Normal button" (anything else actually).
            //Since this is Async, while the long operation is running in the background
            //one can do other operations like click on "Normal button"
            AsyncClickCommand = new Command(async () => {
                await Task.Delay(10000); //in real world equate this to a long operation like reading a big file
                clickTexts.Add("Async button clicked"); 
            });
        }

    }

  
}
