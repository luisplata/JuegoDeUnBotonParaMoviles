public interface ILogicaDeCalculoDePuntuaciones
{
    int AumentarPuntuacion();
    int GetPuntuacion();
    void ActualizarPuntuacion(int puntuacion);
    void CambiarMultiplicador(int multiplicador);
    int Multiplicador();
}