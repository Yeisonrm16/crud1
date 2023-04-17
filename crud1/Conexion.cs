using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;
using Java.Security;
using Java.Util;

namespace crud1
{
    #region Uso de datos de un usuario

//tabla de administradores
    public class Login
    {
        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { set; get; }

        [MaxLength(20)]
        public string Usuario { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }
    }


    #region Uso de datos para el crear ticket

    //tabla de estudiantes
    public class TableUsuario
    {
        public TableUsuario() { }

        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Facultad { get; set; }
        [MaxLength(20)]
        public string CrrUni { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
    }

    //tabla de docentes

    public class TableDocentes
    {
        public TableDocentes() { }

        [PrimaryKey, AutoIncrement]
        public int IdDocente { set; get; }

        [MaxLength(50)]
        public string NombreDocente { get; set; }

        [MaxLength(20)]
        public string FacultadDocente { get; set; }
        [MaxLength(20)]
        public string MateriaDocente { get; set; }
        [MaxLength(30)]
        public string EmailDocente { get; set; }
    }

    //tabla de materias

    public class TableMaterias
    {
        public TableMaterias() { }

        [PrimaryKey, AutoIncrement]
        public int IdMateria { set; get; }

        [MaxLength(50)]
        public string NombreMateria { get; set; }


    }


    #endregion

    #region Manejo de datos y conexion a BD
    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;
        public Auxiliar() //Esto es un constructor
        {
            conexion = ConectarBD();
            conexion.CreateTable<Login>();
            conexion.CreateTable<TableUsuario>();
            conexion.CreateTable<TableDocentes>();
            conexion.CreateTable<TableMaterias>();
        }

        public SQLite.SQLiteConnection ConectarBD()
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "asesoria.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        //Selecionar 1 registro
        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Usuario == NombreUsuario && x.Password == ClaveUsuario);
            }
        }

        public Login Buscar(int Id)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Id == Id);
            }
        }

        public TableUsuario Consultar (int Id)
        {
            lock (locker)
            {
                return conexion.Table<TableUsuario>().FirstOrDefault(x => x.Id == Id);
            }
        }


       

        ////Selecionar todos los usuarios registrados
        public IEnumerable<TableUsuario> SelecionarTodosUsuarios()
        {
            lock (locker)
            {
                return (from i in conexion.Table<TableUsuario>() select i).ToList();
            }
        }

        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }
        //Insertar Estudiante
        public int InsertarEstudiante(TableUsuario registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        //Eliminar Registro de usuario
        public int EliminarRegistro(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }

        //Eliminar Usuario
        public int EliminarUsuario(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<TableUsuario>(ID);
            }
        }

        //crud para docentes

        public int GuardarDocente(TableDocentes registro)
        {
            lock (locker)
            {
                if (registro.IdDocente == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        public TableDocentes BuscarDocente(int IdDocente)
        {
            lock (locker)
            {
                return conexion.Table<TableDocentes>().FirstOrDefault(x => x.IdDocente == IdDocente);
            }
        }

        public int EliminarDocente(int IdDocente)
        {
            lock (locker)
            {
                return conexion.Delete<TableDocentes>(IdDocente);
            }
        }



        //crud para materias

        public int GuardarMateria(TableMaterias registro)
        {
            lock (locker)
            {
                if (registro.IdMateria == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }

        public TableMaterias BuscarMateria(int IdMateria)
        {
            lock (locker)
            {
                return conexion.Table<TableMaterias>().FirstOrDefault(x => x.IdMateria == IdMateria);
            }
        }

        public int EliminarMateria(int IdMateria)
        {
            lock (locker)
            {
                return conexion.Delete<TableMaterias>(IdMateria);
            }
        }

    }
    #endregion
}
#endregion