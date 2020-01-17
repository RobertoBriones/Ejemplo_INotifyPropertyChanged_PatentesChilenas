using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ejemplo_INotifyPropertyChanged_Patentes.Model;
using Ejemplo_INotifyPropertyChanged_Patentes.Servicios;
using Newtonsoft.Json;


namespace Ejemplo_INotifyPropertyChanged_Patentes.ViewModel
{
    public class PatenteViewModel: BaseViewModel
    {


        #region Atributos

        private string _rut;
        private string _patente;

        #endregion


        #region Propiedades

        public BindingList<PatenteModel> ConsultaViewModel { get; set; }

        public string RutBuscar
        {
            get { return _rut; }
            set
            {
                _rut = FormatearRut(value);
                this.OnPropertyChanged();
                if (value.Length > 6)
                {
                    if (ValidarRut(value))
                    {
                        BuscarAutos("Rut");
                    }
                }
                else
                {
                    ConsultaViewModel.Clear();
                }

            }
        }

        public string PatenteBuscar
        {
            get { return _patente; }
            set
            {
                this._patente = value.ToUpper();
                this.OnPropertyChanged();
                if (value.Length == 6)
                {
                    BuscarAutos("Patente");
                }
                else
                {
                    ConsultaViewModel.Clear();
                }
            }
        }

        #endregion


        #region Constructor

        public PatenteViewModel()
        {
            if (ConsultaViewModel == null)
            {
                ConsultaViewModel = new BindingList<PatenteModel>();
            }
        }

        #endregion


        #region Procedimientos


        

        public void BuscarAutos(string valor)
        {
            ConsultaViewModel.Clear();
            string dato="";
            string dato2 = "";

            switch (valor)
            {
                case "Patente":
                    dato = this.PatenteBuscar;
                    dato2 = "pat";
                    break;

                case "Rut":
                    dato = this.RutBuscar;
                    dato2 = "rut";
                    break;

                default:
                    break;
            }

            ServicioWeb web = new ServicioWeb();
            var json = web.GetDatos(dato, dato2);
            List<List<string>> post = JsonConvert.DeserializeObject<List<List<string>>>(@json);

            for (int i = 0; i < post.Count; i++)
            {
                PatenteModel b = new PatenteModel();

                b.Patente = post[i][0];
                b.Tipo = post[i][1];
                b.Marca = post[i][2];
                b.Modelo = post[i][3];
                b.Rut = post[i][4];
                b.Motor = post[i][5];
                b.Año = post[i][6];
                b.Propietario = post[i][7];

                ConsultaViewModel.Add(b);
            }



        }


        public bool ValidarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }

            }
            catch (Exception)
            {
            }
            return validacion;
        }

        private string FormatearRut(string rut)
        {
            int cont = 0;
            string format;
            if (rut is null)
            {
                return "";
            }

            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        #endregion


    }
}
