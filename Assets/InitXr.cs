using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Management;

public class InitXr : MonoBehaviour
{
    private void Awake()
    {
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            LoaderUtility.Initialize();
            SceneManager.LoadScene("Lidar Feed", LoadSceneMode.Single);
        }
    }
}