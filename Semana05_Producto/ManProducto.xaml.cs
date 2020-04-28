using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using Business;

namespace Semana05_Producto
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }

        public ManProducto(int id)
        {
            InitializeComponent();
            ID = id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombre.Text = productos[0].NombreProducto;
                    txtPrecio.Text = productos[0].PrecioUnidad.ToString();
                    txtStock.Text = productos[0].UnidadesEnExistencia.ToString();
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                    result = bProducto.Actualizar(new Producto {IdProducto = ID, NombreProducto = txtNombre.Text, PrecioUnidad = Convert.ToInt32(txtPrecio.Text) ,UnidadesEnExistencia = Convert.ToInt32(txtStock.Text) });
                else
                    result = bProducto.Insertar(new Producto { NombreProducto = txtNombre.Text, PrecioUnidad = Convert.ToInt32(txtPrecio.Text), UnidadesEnExistencia = Convert.ToInt32(txtStock.Text) });
                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                result = bProducto.Eliminar(ID);
                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");
                else
                    MessageBox.Show("Eliminado correctamente");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
        }
    }
}
