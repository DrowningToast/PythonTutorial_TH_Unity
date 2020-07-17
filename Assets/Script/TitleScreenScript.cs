using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;



public class TitleScreenScript : MonoBehaviour
{
    async public void trigger_start()
    {
        Debug.Log(MainScript.CallVarible.CurrentlyOnScene);
        MainScript.CallVarible.CurrentlyOnScene = 1;
        await Task.Delay(2500);
        SceneManager.LoadScene(1);
        
    }
    
}
