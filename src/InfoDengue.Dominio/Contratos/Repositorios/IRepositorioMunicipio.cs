using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Contratos.Repositorios;

public interface IRepositorioMunicipio : IRepositorio<Municipio>
{
    Task<Municipio?> BuscarPorNomeAsync(string nome);
}