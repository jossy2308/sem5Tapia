using sem5Tapia.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sem5Tapia
{
    public class PersonaRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }
        public PersonaRepository(string dbPath1)
        {
            dbPath = dbPath1;
        }
        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre Requerido");
                Persona persona = new Persona() { Name = nombre };
                result = conn.Insert(persona);
                StatusMessage = string.Format("Filas agregadas", result, nombre);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al insertar", nombre, ex.Message);
            }
        }
        public List<Persona> GetAllPeorle()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostrar los datos", ex.Message);
            }
            return new List<Persona>();
        }
        public Persona GetPersonById(int personId)
        {
            try
            {
                Init();
                return conn.Table<Persona>().FirstOrDefault(p => p.Id == personId);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al obtener la persona por ID: {0}", ex.Message);
                return null;
            }
        }

        public void DeletePerson(int personId)
        {
            try
            {
                Init();
                int result = conn.Delete<Persona>(personId);
                StatusMessage = string.Format("Filas eliminadas: {0}, Id: {1}", result, personId);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar: {0}", ex.Message);
            }
        }

        public void UpdatePerson(Persona updatedPerson)
        {
            try
            {
                Init();
                int result = conn.Update(updatedPerson);
                StatusMessage = string.Format("Filas actualizadas: {0}, Id: {1}", result, updatedPerson.Id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar: {0}", ex.Message);
            }


        }
    }
    
}
