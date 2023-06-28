using System.Windows.Forms;

namespace GrupoTranspaisDanielTorres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnCargar.Click += Btn_Click;
            btnGuardar.Click += Btn_Click;
        }

        internal void Btn_Click(object? o, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (o == btnCargar)
            {
                CargarExcell();
            }
            else if (o == btnGuardar)
            {
                Guardar();
            }
            Cursor.Current = Cursors.Default;
        }

        private void Guardar()
        {
            List<Persona> Personas = new List<Persona>();
            Persona persona = new Persona();
            if (!string.IsNullOrEmpty(txtUrl.Text))
            {
                Personas = Archivo.ObtenerInfo(txtUrl.Text);
                persona.GuardarInfo(Personas);
            }
            else
            {
                MessageBox.Show("Seleccione un archivo de su equipo");
            }
        }

        internal void CargarExcell()
        {
            List<Persona> Personas = new List<Persona>();

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Title = "Seleccionar Archivo",
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    CheckFileExists = true,
                    Multiselect = false,
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Personas = Archivo.ObtenerInfo(openFileDialog.FileName);
                    txtUrl.Text = openFileDialog.FileName;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}