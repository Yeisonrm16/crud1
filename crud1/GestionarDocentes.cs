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
    [Activity(Label = "GestionarDocentes")]
    public class GestionarDocentes : Activity
    {
        EditText txtIdDocente;
        EditText txtNombreDocente;
        EditText txtFacultadDocente;
        EditText txtMateriaDocente;
        EditText txtEmailDocente;

        Button btnCrearDocente;
        Button btnConsultarDocente;
        Button btnActualizarDocente;
        Button btnEliminarDocente;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GestionarDocentes);
            // Create your application here

            txtIdDocente = FindViewById<EditText>(Resource.Id.txtIdDocente);
            txtNombreDocente = FindViewById<EditText>(Resource.Id.txtNombreDocente);
            txtFacultadDocente = FindViewById<EditText>(Resource.Id.txtFacultadDocente);
            txtMateriaDocente = FindViewById<EditText>(Resource.Id.txtMateriaDocente);
            txtEmailDocente = FindViewById<EditText>(Resource.Id.txtEmailDocente);

            btnCrearDocente = FindViewById<Button>(Resource.Id.btnCrearDocente);
            btnConsultarDocente = FindViewById<Button>(Resource.Id.btnConsultarDocente);
            btnActualizarDocente = FindViewById<Button>(Resource.Id.btnActualizarDocente);
            btnEliminarDocente = FindViewById<Button>(Resource.Id.btnEliminarDocente);



            btnCrearDocente.Click += BtnCrearDocente_Click;
            btnConsultarDocente.Click += btnConsultarDocente_Click;
            btnActualizarDocente.Click += btnActualizarDocente_Click;
            btnEliminarDocente.Click += btnEliminarDocente_Click;
        }

        private void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdDocente.Text.Trim()))
                {

                    new Auxiliar().EliminarDocente(int.Parse(txtIdDocente.Text));


                    Toast.MakeText(this, "Datos eliminados exitosamente", ToastLength.Long).Show();
                    txtIdDocente.Text = "";
                    txtNombreDocente.Text = "";
                    txtFacultadDocente.Text = "";
                    txtMateriaDocente.Text = "";
                    txtEmailDocente.Text = "";

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



        private void btnActualizarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombreDocente.Text.Trim()) && !string.IsNullOrEmpty(txtFacultadDocente.Text.Trim()) && !string.IsNullOrEmpty(txtMateriaDocente.Text.Trim()) && !string.IsNullOrEmpty(txtEmailDocente.Text.Trim()))
                {

                    new Auxiliar().GuardarDocente(new TableDocentes()
                    {
                        IdDocente = int.Parse(txtIdDocente.Text.Trim()),
                        NombreDocente = txtNombreDocente.Text.Trim(),
                        FacultadDocente = txtFacultadDocente.Text.Trim(),
                        MateriaDocente = txtMateriaDocente.Text.Trim(),
                        EmailDocente = txtEmailDocente.Text.Trim(),
                    });


                    Toast.MakeText(this, "Datos ACTUALIZADOS", ToastLength.Long).Show();
                    txtIdDocente.Text = "";
                    txtNombreDocente.Text = "";
                    txtFacultadDocente.Text = "";
                    txtMateriaDocente.Text = "";
                    txtEmailDocente.Text = "";

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



        //-----------------------------------------BOTON CONSULTAR DOCENTE---------
        private void btnConsultarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                TableDocentes resultado = null;
                if (!String.IsNullOrEmpty(txtIdDocente.Text.Trim()))
                {
                    resultado = new Auxiliar().BuscarDocente(int.Parse(txtIdDocente.Text.Trim()));
                    if (resultado != null)
                    {

                        txtNombreDocente.Text = resultado.NombreDocente.ToString();
                        txtFacultadDocente.Text = resultado.FacultadDocente.ToString();
                        txtMateriaDocente.Text = resultado.EmailDocente.ToString();
                        txtEmailDocente.Text = resultado.EmailDocente.ToString();

                        Toast.MakeText(this, "Consulta Exitosa", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Error en la consulta, consulte otro ID", ToastLength.Short).Show();
                        txtNombreDocente.Text = "";
                        txtFacultadDocente.Text = "";
                        txtMateriaDocente.Text = "";
                        txtEmailDocente.Text = "";

                    }


                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

//------------------------BOTON CREAR DOCENTE--------------------
        private void BtnCrearDocente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombreDocente.Text.Trim()))
                {
                    new Auxiliar().GuardarDocente(new TableDocentes()
                    {
                        IdDocente = 0,
                        NombreDocente = txtNombreDocente.Text.Trim(),
                        FacultadDocente = txtFacultadDocente.Text.Trim(),
                        MateriaDocente = txtMateriaDocente.Text.Trim(),
                        EmailDocente = txtEmailDocente.Text.Trim()
                    });
                    Toast.MakeText(this, "Registro de docente Guardado", ToastLength.Long).Show();
                    txtNombreDocente.Text = "";
                    txtFacultadDocente.Text = "";
                    txtMateriaDocente.Text = "";
                    txtEmailDocente.Text = "";
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