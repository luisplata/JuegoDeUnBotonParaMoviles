using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ServicioDePlayFabnube : IServicioDeGuardado
{
    private string _titleIdLocal;
    private IConversorDeJson conversor;

    public ServicioDePlayFabnube(string titleId)
    {
        _titleIdLocal = titleId;
        conversor = new ConversorDeJson();
    }

    public DatoDelCliente ConsultarData()
    {
        DatoDelCliente datodDelCliente = default;
        GetUserDataRequest req = new GetUserDataRequest
        {
            Keys = new List<string>() { "configuracionDelUsuario" }
        };
        PlayFabClientAPI.GetUserData(req, ok => 
        {
            var datos = ok.Data["configuracionDelUsuario"];
            datodDelCliente = conversor.JsonToType<DatoDelCliente>(datos.Value);
        }, OnLoginFailure);

        return datodDelCliente;
    }

    public async Task GuardarData(DatoDelCliente datoDelCliente)
    {
        await UsuarioEsValido();
        CommandQueue.Instance.AddCommand(new ComandoDeGuardado(datoDelCliente));
    }

    public async Task<bool> UsuarioEsValido()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = _titleIdLocal;
        }

#if UNITY_ANDROID
        LoginWithAndroidDeviceIDRequest req = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithAndroidDeviceID(req, OnLoginSuccess, OnLoginFailure);
#elif UNITY_IOS
        LoginWithIOSDeviceIDRequest reqiOS = new LoginWithIOSDeviceIDRequest
        {
            DeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithAndroidDeviceID(req, OnLoginSuccess, OnLoginFailure);

#else
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
#endif
        return true;
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Ok: "+result.SessionTicket);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        throw new ErrorEnLaConsultaAlServicorException(error.GenerateErrorReport());
    }
}
