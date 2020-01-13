
namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public class PatenteModel : BaseViewModel
    {

        private string _patente;
        public string Patente
        {
            get { return _patente; }
            set
            {
                _patente = value; this.OnPropertyChanged();
            }
        }

        private string _propietario;

        public string Propietario
        {
            get { return _propietario; }
            set { _propietario = value; this.OnPropertyChanged(); }
        }


        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set
            {
                _rut = value; this.OnPropertyChanged();
            }
        }

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this.OnPropertyChanged(); }
        }

       

        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; this.OnPropertyChanged(); }
        }


        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; this.OnPropertyChanged(); }
        }

        private string _año;

        public string Año
        {
            get { return _año; }
            set { _año = value; this.OnPropertyChanged(); }
        }

        private string _motor;

        public string Motor
        {
            get { return _motor; }
            set { _motor = value; this.OnPropertyChanged(); }
        }

        
    }
    
}
