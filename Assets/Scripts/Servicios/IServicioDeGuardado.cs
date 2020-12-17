using System.Threading.Tasks;

public interface IServicioDeGuardado
{

    Task<bool> UsuarioEsValido();
    Task GuardarData(DatoDelCliente datoDelCliente);
    DatoDelCliente ConsultarData();
}
