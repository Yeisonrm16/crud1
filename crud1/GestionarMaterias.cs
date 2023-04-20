using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud1
{
    [Activity(Label = "GestionarMaterias")]
    public class GestionarMaterias : Activity
    {
        
        EditText txtIdMateria;
        EditText txtNombreMateria;
       

        Button btnCrearMateria;
        Button btnConsultarMateria;
        Button btnActualizarMateria;
        Button btnEliminarMateria;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GestionarMaterias);

            txtIdMateria = FindViewById<EditText>(Resource.Id.txtIdMateria);
            txtNombreMateria = FindViewById<EditText>(Resource.Id.txtNombreMateria);


            btnCrearMateria = FindViewById<Button>(Resource.Id.btnCrearMateria);
            btnConsultarMateria = FindViewById<Button>(Resource.Id.btnConsultarMateria);
            btnActualizarMateria = FindViewById<Button>(Resource.Id.btnActualizarMateria);
            btnEliminarMateria = FindViewById<Button>(Resource.Id.btnEliminarMateria);


            btnCrearMateria.Click += BtnCrearMateria_Click;
            btnConsultarMateria.Click += btnConsultarMateria_Click;
            btnActualizarMateria.Click += btnActualizarMateria_Click;
            btnEliminarMateria.Click += btnEliminarMateria_Click;

        }

        //-------------------------------BOTON ELIMINAR MATERIAS------------------------
        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                TableMaterias resultado = null;
                if (!string.IsNullOrEmpty(txtIdMateria.Text.Trim()))
                {

                    new Auxiliar().EliminarMateria(int.Parse(txtIdMateria.Text));


                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtIdMateria.Text = "";
                    txtNombreMateria.Text = "";
                    

                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese ID valido ", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }



        //-----------------------------------------BOTON ACTUALIZAR MATERIAS-------------
        private void btnActualizarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombreMateria.Text.Trim()))
                {

                    new Auxiliar().GuardarMateria(new TableMaterias()
                    {
                        IdMateria = int.Parse(txtIdMateria.Text.Trim()),
                        NombreMateria = txtNombreMateria.Text.Trim(),
                        
                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtIdMateria.Text = "";
                    txtNombreMateria.Text = "";
                    

                }
                else
                {
                    Toast.MakeText(this, "Error al actualizar", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }



        //----------------------------------BOTON BUSCAR MATERIA-----------
        private void btnConsultarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                TableMaterias resultado = null;
                if (!String.IsNullOrEmpty(txtIdMateria.Text.Trim()))
                {
                    resultado = new Auxiliar().BuscarMateria(int.Parse(txtIdMateria.Text.Trim()));
                    if (resultado != null)
                    {

                        txtNombreMateria.Text = resultado.NombreMateria.ToString();
                        

                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la consulta, consulte otro ID", ToastLength.Short).Show();
                        txtIdMateria.Text = "";
                        txtNombreMateria.Text = "";


                    }


                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }


        }


        //----------------------------BOTON GUARDAR MATERIAS--------------------
        private void BtnCrearMateria_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombreMateria.Text.Trim()))
                {
                    new Auxiliar().GuardarMateria(new TableMaterias()
                    {
                        IdMateria = 0,
                        NombreMateria = txtNombreMateria.Text.Trim(),
                        
                    });
                    Toast.MakeText(this, "Registro de materia exitoso", ToastLength.Long).Show();
                    txtIdMateria.Text = "";
                    txtNombreMateria.Text = "";
                   
                }
                else
                {
                    Toast.MakeText(this, "Ingrese los campos requeridos", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}