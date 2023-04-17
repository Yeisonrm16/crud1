using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbar = Android.Widget.Toolbar;

namespace crud1
{
    [Activity(Label = "Bienvenido")]
    public class Bienvenido : Activity
    {
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            SetActionBar(toolbarmenu);
            ActionBar.Title = "Menu";

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Insertar:
                    Intent insertar_est = new Intent(this, typeof(InsertarEstudiante));
                    StartActivity(insertar_est);
                    
                    break;
                case Resource.Id.Buscar:
                    Intent Actualizaciones_usu = new Intent(this, typeof(Actualizaciones));
                    StartActivity(Actualizaciones_usu);

                    break;
                case Resource.Id.GestionDocentes:
                    Intent gestion_doc = new Intent(this, typeof(GestionarDocentes));
                    StartActivity(gestion_doc);

                    break;
                case Resource.Id.GestionMaterias:
                    Intent gestion_mat = new Intent(this, typeof(GestionarMaterias));
                    StartActivity(gestion_mat);

                    break;
                    //case Resource.Id.Modificar:
                    //    //Intent mod_est = new Intent(this, typeof(Modificar));
                    //    //StartActivity(mod_est);
                    //    SetContentView(Resource.Layout.Modificar);
                    //    break;
                    //default:
                    //    break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}
