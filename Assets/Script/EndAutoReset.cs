using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAutoReset : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Hello");
        await Task.Delay(10000);
        Debug.Log("Hello");
        MainScript.CallVarible.CurrentlyOnScene = 0;
        SceneManager.LoadScene(0);

    }
    static public async Task Reset_Timer()
    {
        await Task.Delay(10000);
    }
}
