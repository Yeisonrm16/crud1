using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using crud1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud1
{
    [Activity(Label = "InsertarEstudiante")]

    public class InsertarEstudiante : Activity
    {
        EditText txtId;
        EditText txtNombre;
        EditText txtFacultad;
        EditText txtCrrUni;
        EditText txtEmail;

        Button btnCrearEstudiante;
        Button btnConsultar;
        Button btnActualizarEstudiante1;
        Button btnEliminarEstudiante;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InsertarEstudiante);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtFacultad = FindViewById<EditText>(Resource.Id.txtFacultad);
            txtCrrUni = FindViewById<EditText>(Resource.Id.txtCrrUni);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            
            btnCrearEstudiante = FindViewById<Button>(Resource.Id.btnCrearEstudiante);
            btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);
            btnActualizarEstudiante1 = FindViewById<Button>(Resource.Id.btnActualizarEstudiante);
            btnEliminarEstudiante = FindViewById<Button>(Resource.Id.btnEliminarEstudiante);



            btnCrearEstudiante.Click += BtnCrearTicket_Click;
            btnConsultar.Click += btnConsultar_Click;
            btnActualizarEstudiante1.Click += btnActualizarEstudiante1_Click;
            btnEliminarEstudiante.Click += btnEliminarEstudiante_Click;



        }

        private void btnEliminarEstudiante_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {

                    new Auxiliar().EliminarUsuario(int.Parse(txtId.Text));
       

                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtFacultad.Text = "";
                    txtCrrUni.Text = "";
                    txtEmail.Text = "";

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




        private void btnActualizarEstudiante1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtFacultad.Text.Trim()) && !string.IsNullOrEmpty(txtCrrUni.Text.Trim()) && !string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {

                    new Auxiliar().InsertarEstudiante(new TableUsuario()
                    {
                        Id = int.Parse(txtId.Text.Trim()),
                        Nombre = txtNombre.Text.Trim(),
                        Facultad = txtFacultad.Text.Trim(),
                        CrrUni = txtCrrUni.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtFacultad.Text = "";
                    txtCrrUni.Text = "";
                    txtEmail.Text = "";

                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }

        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                TableUsuario resultado = null;
                if (!String.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    resultado = new Auxiliar().Consultar (int.Parse(txtId.Text.Trim()));
                    if (resultado != null)
                    {
                        
                        txtNombre.Text = resultado.Nombre.ToString();
                        txtFacultad.Text = resultado.Facultad.ToString();
                        txtCrrUni.Text = resultado.CrrUni.ToString();
                        txtEmail.Text = resultado.Email.ToString();

                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la cinsulta,sonsulte otro ID", ToastLength.Short).Show();
                        txtNombre.Text = "";
                        txtFacultad.Text = "";
                        txtCrrUni.Text = "";
                        txtEmail.Text = "";

                    }


                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }


        private void BtnRegistrar_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegistrarUsuario));
            StartActivity(i);
        }


        private void BtnCrearTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    new Auxiliar().InsertarEstudiante(new TableUsuario()
                    {
                        Id = 0,
                        Nombre = txtNombre.Text.Trim(),
                        Facultad = txtFacultad.Text.Trim(),
                        CrrUni = txtCrrUni.Text.Trim(),
                        Email = txtEmail.Text.Trim()
                    });
                    Toast.MakeText(this, "Registro Guardado", ToastLength.Long).Show();
                    txtNombre.Text = "";
                    txtFacultad.Text = "";
                    txtCrrUni.Text = "";
                    txtEmail.Text = "";
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