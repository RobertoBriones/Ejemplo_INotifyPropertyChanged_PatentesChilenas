using System.Windows.Forms;
using Ejemplo_INotifyPropertyChanged_Patentes.ViewModel;
namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public partial class Form1 : Form
    {
        private PatenteViewModel _patente = new PatenteViewModel();


        public Form1()
        {
            InitializeComponent();

            textBox1.DataBindings.Add("Text", _patente, nameof(_patente.PatenteBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", _patente, nameof(_patente.RutBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
          
            dataGridView1.DataSource = _patente.ConsultaViewModel;
            dataGridView1.Columns[0].Width = 48;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[6].Width = 34;
        }

        

        

    }

}
