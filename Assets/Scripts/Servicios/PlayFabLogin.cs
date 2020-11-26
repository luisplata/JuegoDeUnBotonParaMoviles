using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }

#if UNITY_ANDROID
        LoginWithAndroidDeviceIDRequest req = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true
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
    }

    private void OnLoginSuccess(LoginResult result)
    {

        GetUserDataRequest req = new GetUserDataRequest
        {
            Keys = new List<string>() { "configuracionDelUsuario" }
        };
        PlayFabClientAPI.GetUserData(req, ok => {
            var datos = ok.Data["configuracionDelUsuario"];
            var datodDelCliente = JsonUtility.FromJson<DatoDelCliente>(datos.Value);
            Debug.Log(datodDelCliente.yaLogeo);
        }, error => { });

        //actualizar la data del usuario
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"configuracionDelUsuario" , JsonUtility.ToJson(
                    new DatoDelCliente{
                            puntuacion = 0, yaLogeo = true
                        }
                    )
                }
            }
        }, 
        ok => { }, error => { });
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}