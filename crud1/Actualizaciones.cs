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
    [Activity(Label = "Actualizaciones")]
    public class Actualizaciones : Activity
    {

        EditText txtId;
        EditText txtUsuario;
        EditText txtPassword;

        Button btnBuscar;
        Button btnEliminar;
        Button btnActualizar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Actualizaciones);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            btnActualizar = FindViewById<Button>(Resource.Id.btnActualizar);
            btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);



            btnBuscar.Click += BtnBuscar_Click;

            btnEliminar.Click += BtnEliminar_Click;

            btnActualizar.Click += BtnActualizar_Click;




        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {

                    new Auxiliar().Guardar(new Login()
                    {
                        Id = int.Parse(txtId.Text.Trim()),
                        Usuario = txtUsuario.Text.Trim(),
                        Password = txtPassword.Text.Trim(),

                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtUsuario.Text = "";
                    txtPassword.Text = "";

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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {

                    new Auxiliar().EliminarRegistro(int.Parse(txtId.Text));


                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtId.Text = "";
                    txtUsuario.Text = "";
                    txtPassword.Text = "";


                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un ID valido ", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!String.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    resultado = new Auxiliar().Buscar(int.Parse(txtId.Text.Trim()));
                    if (resultado != null)
                    {
                        txtUsuario.Text = resultado.Usuario.ToString();
                        txtPassword.Text = resultado.Password.ToString();
                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la consulta, consulte con otro ID", ToastLength.Short).Show();
                        txtUsuario.Text = "";
                        txtPassword.Text = "";

                    }


                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }

}