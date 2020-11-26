using System.Threading.Tasks;

public interface IServicioDePlayFabNube
{

    Task<bool> UsuarioEsValido();
    Task GuardarData(DatoDelCliente datoDelCliente);
    DatoDelCliente ConsultarData();
}