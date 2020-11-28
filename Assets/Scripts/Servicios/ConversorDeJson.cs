using UnityEngine;

public class ConversorDeJson : IConversorDeJson
{
    public T JsonToType<T>(string value)
    {
        return JsonUtility.FromJson<T>(value);
    }
}