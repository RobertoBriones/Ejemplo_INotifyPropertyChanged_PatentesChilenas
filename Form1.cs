using System.Windows.Forms;

namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public partial class Form1 : Form
    {
        private Buscar _patente = new Buscar();


        public Form1()
        {
            InitializeComponent();

            this.textBox1.DataBindings.Add("Text", this._patente, nameof(this._patente.PatenteBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox2.DataBindings.Add("Text", this._patente, nameof(this._patente.RutBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
          
            this.dataGridView1.DataSource = this._patente.ConsultaViewModel;
            dataGridView1.Columns[0].Width = 48;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[6].Width = 34;
        }

        

        

    }

}
