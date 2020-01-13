using System;
using System.ComponentModel;


namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public class Buscar: BaseViewModel
    {
        private string _rut;

        public string RutBuscar
        {
            get { return _rut; }
            set
            {
                this._rut = FormatearRut(value);
                this.OnPropertyChanged();
                if (value.Length > 3)
                {
                    if (ValidarRut(value))
                    {
                        GetAutos();
                    }
                }
            }
        }

        private string _patente;
        public string PatenteBuscar
        {
            get { return _patente; }
            set
            {
                this._patente = value.ToUpper();
                this.OnPropertyChanged();
                if (value.Length == 6)
                {
                    GetPatente();
                }
            }
        }

        public BindingList<PatenteModel> ConsultaViewModel { get; set; }

        public Buscar()
        {
            if (ConsultaViewModel == null)
            {
                ConsultaViewModel = new BindingList<PatenteModel>();
            }
        }
        private void GetPatente()
        {
            ConsultaViewModel.Clear();



            ServicioWeb web = new ServicioWeb();
            var result2 = web.GetDatos(this.PatenteBuscar, "pat");


            string[] stringSeparators = new string[] { "<td>" };
            string[] stringSeparators2 = new string[] { "</td>" };
            var stringSeparators3 = new string[] { ">" };
            var stringSeparators4 = new string[] { "<" };

            var result3 = result2.Split(stringSeparators, StringSplitOptions.None);

            PatenteModel b = new PatenteModel();

            b.Patente = result3[1].Split(stringSeparators2, StringSplitOptions.None)[0];
            b.Tipo = result3[2].Split(stringSeparators2, StringSplitOptions.None)[0];
            b.Marca = result3[3].Split(stringSeparators2, StringSplitOptions.None)[0];
            
            var AUX = result3[4].Split(stringSeparators2, StringSplitOptions.None);
            b.Modelo = AUX[0];
            b.Rut = AUX[1].Split(stringSeparators3, StringSplitOptions.None)[1];
           
            b.Motor = result3[5].Split(stringSeparators2, StringSplitOptions.None)[0];
            b.Año = result3[6].Split(stringSeparators2, StringSplitOptions.None)[0];
            
            var nombre = result3[7].Split(stringSeparators3, StringSplitOptions.None)[1];
            b.Propietario = nombre.Split(stringSeparators4, StringSplitOptions.None)[0];


            ConsultaViewModel.Add(b);

        }


        public void GetAutos()
        {
            ConsultaViewModel.Clear();


            ServicioWeb web = new ServicioWeb();
            var result2 = web.GetDatos(this.RutBuscar, "rut");

            string[] stringSeparators21 = new string[] { string.Format("<tr tabindex=\"1\">") };
            var result21 = result2.Split(stringSeparators21, StringSplitOptions.RemoveEmptyEntries);




            string[] stringSeparators = new string[] { "<td>" };
            string[] stringSeparators2 = new string[] { "</td>" };
            var stringSeparators3 = new string[] { ">" };
            var stringSeparators4 = new string[] { "<" };



            for (int i = 1; i < result21.Length; i++)
            {
                var a = result21[i];
                var result3 = a.Split(stringSeparators, StringSplitOptions.None);
                
                PatenteModel b = new PatenteModel();

                b.Patente= result3[1].Split(stringSeparators2, StringSplitOptions.None)[0];
                b.Tipo = result3[2].Split(stringSeparators2, StringSplitOptions.None)[0];
                b.Marca = result3[3].Split(stringSeparators2, StringSplitOptions.None)[0];
                var AUX = result3[4].Split(stringSeparators2, StringSplitOptions.None);
                b.Modelo = AUX[0];
                b.Rut = AUX[1].Split(stringSeparators3, StringSplitOptions.None)[1];
                b.Motor = result3[5].Split(stringSeparators2, StringSplitOptions.None)[0];
                b.Año = result3[6].Split(stringSeparators2, StringSplitOptions.None)[0];
                var nombre = result3[7].Split(stringSeparators3, StringSplitOptions.None)[1];
                b.Propietario = nombre.Split(stringSeparators4, StringSplitOptions.None)[0];
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
    }
}
