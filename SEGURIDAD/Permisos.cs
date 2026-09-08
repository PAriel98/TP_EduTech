using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTech;

namespace SERVICIOS
{
    public static class Permisos
    {
        public static bool TienePermiso(UsuarioBE usuario,string permiso)
        {
            return usuario.FAMILIAS.SelectMany(f => f.Permisos).Any(p => p.Nombre == permiso);
        }


    }
}
