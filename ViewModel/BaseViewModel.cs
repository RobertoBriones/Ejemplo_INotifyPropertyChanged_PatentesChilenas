using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Ejemplo_INotifyPropertyChanged_Patentes.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region Propiedades

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Metodos

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

