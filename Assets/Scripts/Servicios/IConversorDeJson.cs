public interface IConversorDeJson
{
    T JsonToType<T>(string value);
}