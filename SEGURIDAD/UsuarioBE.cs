using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTech
{
    public class UsuarioBE
    {
        private string _usuario;

        public string USUARIO
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _clave;

        public string CLAVE
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private string _rol;

        public string ROL
        {
            get { return _rol; }
            set { _rol = value; }
        }

        private string _nombre;

        public string NOMBRE
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string APELLIDO
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _dni;

        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private string _telefono;

        public string TELEFONO
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _email;

        public string EMAIL
        {
            get { return _email; }
            set { _email = value; }
        }

        private List<FamiliaBE> _familias;

        public List<FamiliaBE> FAMILIAS
        {
            get { return _familias; }
            set { _familias = value; }
        }

        public UsuarioBE()
        {
            FAMILIAS = new List<FamiliaBE>();
        }

        
        public UsuarioBE(string usuario, string clave, string rol, string nombre, string apellido, string dni, string telefono, string email)
        {
            _usuario = usuario;
            _clave = clave;
            _rol = rol;
            _nombre = nombre;
            _apellido = apellido;
            _dni = dni;
            _telefono = telefono;
            _email = email;

            FAMILIAS = new List<FamiliaBE>();
        }

        public override string ToString()
        {
            return USUARIO + "|" + CLAVE + "|" + ROL + "|" + NOMBRE + "|" + APELLIDO + "|" + DNI + "|" + TELEFONO + "|" + EMAIL + "|".ToString();
        }

        public static UsuarioBE DesdeLaLinea(string linea)
        {
            string[] partes = linea.Split('|');
            UsuarioBE usuario = new UsuarioBE(partes[0], partes[1], partes[2], partes[3], partes[4], partes[5], partes[6], partes[7]);
            return usuario;


        }
        ~UsuarioBE() { }
    }
}
