using System.Windows.Forms;

namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public partial class Form1 : Form
    {
        private Buscar _datos = new Buscar();


        public Form1()
        {
            InitializeComponent();

            this.textBox1.DataBindings.Add("Text", this._datos, nameof(this._datos.PatenteBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox2.DataBindings.Add("Text", this._datos, nameof(this._datos.RutBuscar), true, DataSourceUpdateMode.OnPropertyChanged);
          
            this.dataGridView1.DataSource = this._datos.ConsultaViewModel;
            dataGridView1.Columns[0].Width = 48;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[6].Width = 34;
        }

        

        

    }

}
