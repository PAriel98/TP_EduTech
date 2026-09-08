using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduTech
{
    public class UsuarioDAL:IAMBusuario<UsuarioBE>
    {
        private static UsuarioDAL _instancia;
        private static readonly object _lock = new object();
        private static string ruta = "usuarios.txt";

        public UsuarioDAL()
        {
            InicializarArchivo(ruta);
        }
        private void InicializarArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                Seguridad.Guardar(ruta, "", false); 
            }
        }

        public static UsuarioDAL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                            _instancia = new UsuarioDAL();
                    }
                }
                return _instancia;
            }
        }

        public void Agregar(UsuarioBE usuario)
        {
            Seguridad.Guardar(ruta, usuario.ToString(), true);
        }

        public List<UsuarioBE> buscar(string criterio, string criterio2)
        {
            var lista = Listar();
            var resultados = new List<UsuarioBE>();
            foreach (UsuarioBE usuario in lista)
            {
                if (criterio2 == "DNI" && usuario.DNI.ToLower().Contains(criterio.ToLower()))
                {
                    resultados.Add(usuario);
                }
            }
            return resultados;
        }

        public void Eliminar(string criterio, string criterio2)
        {
            var lista = Listar();
            lista.RemoveAll(u => u.DNI == criterio);
            GuardarNLista(lista);
        }

        public void GuardarNLista(List<UsuarioBE> lista)
        {
            foreach (var u in lista)
            {
                Seguridad.Guardar(ruta, u.ToString(), u != lista.First());
            }
        }

        public List<UsuarioBE> Listar()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();

            try
            {
                
                var lineas = Seguridad.Leer(ruta);
                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                        lista.Add(UsuarioBE.DesdeLaLinea(linea));
                }
            }
            catch
            {
                
                if (File.Exists(ruta))
                {
                    var lineas = File.ReadAllLines(ruta);
                    foreach (var linea in lineas)
                    {
                        if (!string.IsNullOrWhiteSpace(linea))
                            lista.Add(UsuarioBE.DesdeLaLinea(linea));
                    }

                    
                    GuardarNLista(lista);
                }
            }

            return lista;
        }

        public void Modificar(UsuarioBE Umodificado)
        {
            var lista = Listar();
            int index = lista.FindIndex(u => u.DNI == Umodificado.DNI);
            if (index >= 0)
            {
                lista[index] = Umodificado;
                GuardarNLista(lista);
            }
        }
    }
}
