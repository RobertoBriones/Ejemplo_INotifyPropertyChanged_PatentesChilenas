using System.Windows.Forms;

namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public partial class Form1 : Form
    {
        private Patente _datos = new Patente();


        public Form1()
        {
            InitializeComponent();

            textBox1.DataBindings.Add("Text", _datos, nameof(_datos.PatenteBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", _datos, nameof(_datos.RutBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
          
            dataGridView1.DataSource = _datos.ConsultaViewModel;
            dataGridView1.Columns[0].Width = 48;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[6].Width = 34;
        }

        

        

    }

}
