using CN_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CN_Nego
{
    public class CN_Adoptantes
    {

        private CD_Adoptante objAdoptante = new CD_Adoptante();

        public List<Adoptantes> listar()
        {
            return objAdoptante.Listar();
        }
    }
}
