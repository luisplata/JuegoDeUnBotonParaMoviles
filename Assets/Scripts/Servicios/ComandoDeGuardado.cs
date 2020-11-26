using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ComandoDeGuardado : ICommand
{
    private DatoDelCliente _datoDelCliente;

    public ComandoDeGuardado(DatoDelCliente datoCliente)
    {
        _datoDelCliente = datoCliente;
    }

    public async Task Execute()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"configuracionDelUsuario" , JsonUtility.ToJson(_datoDelCliente)}
            }
        },
        ok => { }, OnLoginFailure);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        throw new ErrorEnLaConsultaAlServicorException(error.GenerateErrorReport());
    }
}
