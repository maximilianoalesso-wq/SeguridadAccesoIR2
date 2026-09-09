using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SeguridadAccessoB.Repositorio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string TemplateHuella { get; set; }
    }
    public class RepUsuarios
    {
        private List<Usuario> _usuarios;
        private int? _proxID; //primary key
        const string ARCHIVO_USUARIOS = "usuarios.json";

        public RepUsuarios()
        {
            if (!File.Exists(ARCHIVO_USUARIOS))
            {
                File.WriteAllText(ARCHIVO_USUARIOS, "[]");
            }
            string contUsuarios = File.ReadAllText(ARCHIVO_USUARIOS);
            _usuarios = JsonSerializer.Deserialize<List<Usuario>>(contUsuarios);
            if (_usuarios.Count > 0)
            {
                _proxID = _usuarios.Max(x => x.Id);
            }
            if (_proxID == null)
            {
                _proxID = 0;
            }
            //acá _proxID va a tener un valor
            _proxID++;  //calculamos el proximo id
        }

        public List<Usuario> GetAll()
        {
            return _usuarios;
        }
        public Usuario GetByID(int idUsuario)
        {
            return _usuarios.Where(u => u.Id == idUsuario).FirstOrDefault();
        }
        public void Post(Usuario usuario)
        {
            usuario.Id = _proxID.Value;
            _proxID++;
            _usuarios.Add(usuario);
            GuardarUsuario();

        }
        public void Put(Usuario usuario)
        {
            GuardarUsuario();
        }
        public void Delete(Usuario usuario)
        {
            _usuarios.Remove(usuario);
            GuardarUsuario();
        }

        private void GuardarUsuario()
        {
            string usuarios = JsonSerializer.Serialize(_usuarios);
            File.WriteAllText(ARCHIVO_USUARIOS, usuarios);
        }
    }
}
