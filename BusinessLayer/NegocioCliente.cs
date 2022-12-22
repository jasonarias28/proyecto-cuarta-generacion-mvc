using DataAccess;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NegocioCliente
    {
        public string Actualizar(ClienteBO dto)
        {
            DAOCliente dao = new DAOCliente();
            return dao.Actualizar(dto);
        } 
        public string Eliminar(string dto)
        {
            DAOCliente dao = new DAOCliente();
            return dao.Eliminar(dto);
        }
        public string Insertar(ClienteBO dto)
        {
            DAOCliente dao = new DAOCliente();
            return dao.Insertar(dto);
        }
        public List<ClienteBO> Listar()
        {
            DAOCliente dao = new DAOCliente();
            return dao.Listar();
        }
    }
}
