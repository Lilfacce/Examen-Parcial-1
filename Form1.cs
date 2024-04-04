using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Parcial_1
{
    public partial class Form1 : Form
    {
        List<Estudiantes> estudiantes = new List<Estudiantes>();
        List<Talleres> talleres = new List<Talleres>();
        List<Inscripcion> inscripcion = new List<Inscripcion>();
        List<Reportes> reportes = new List<Reportes>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Estudiantes.txt";
            string fileName2 = "Talleres.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Estudiantes estudiante = new Estudiantes);
                estudiante.Dpi = Convert.ToInt16(reader.ReadLine());
                estudiante.Nombre = reader.ReadLine();
                estudiante.Direccion = reader.ReadLine();

                estudiantes.Add(estudiante);
            }

            reader.Close();

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Dpi";
            comboBox1.DataSource = estudiantes;
            comboBox1.Refresh();



            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            while (reader2.Peek() > -1)
            {
                Talleres taller = new Talleres();
                taller.Codigo = Convert.ToInt32(reader2.ReadLine());
                taller.Nombre = reader2.ReadLine();
                taller.Costo = Convert.ToDecimal(reader2.ReadLine());

                talleres.Add(taller);
            }

            reader2.Close();

            comboBox2.DisplayMember = "NombreTaller";
            comboBox2.ValueMember = "Codigo";
            comboBox2.DataSource = talleres;
            comboBox2.Refresh();
        }
        private void GuardarInscripciones()
        {

            FileStream stream = new FileStream("Inscripciones.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var inscripcion in inscripcion)
            {
                writer.WriteLine(inscripcion.Dpi);
                writer.WriteLine(inscripcion.Codigo);
                writer.WriteLine(inscripcion.Fecha);
            }

            writer.Close();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            inscripcion.Dpi = Convert.ToInt32(comboBox1.SelectedValue);
            inscripcion.Codigo = Convert.ToInt16(comboBox2.SelectedValue);
            inscripcion.Fecha = DateTime.UtcNow;

            inscripciones.Add(inscripcion);


            GuardarInscripciones();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (var estudiante in estudiantes)
            {
                foreach (var taller in talleres)
                {


                    foreach (var inscripcion in inscripciones)
                    {
                        if (estudiante.Dpi == inscripcion.Dni)
                        {
                            Reportes reporte = new Reportes();
                            reporte.Alumno = estudiante.Nombre;
                            reporte.Taller = taller.Nombre;
                            reporte.Fecha = inscripcion.Fecha;

                            reportes.Add(reporte);

                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = reportes;
                dataGridView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportes = reportes.OrderBy(p => p.Taller).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Cuenta = reportes.Count();
            label4.Text = Cuenta.ToString();
            label3.Visible = true;
            label4.Visible = true;

        }
    }
}

