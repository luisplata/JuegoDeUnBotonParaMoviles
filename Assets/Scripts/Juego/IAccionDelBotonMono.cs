public interface IAccionDelBotonMono
{
    void ActualizarPuntuacion(int puntuacion);
    void ReinciarTiempoDeEspera();
    bool YaGuardoData { get; set; }
}