using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneNavigator : MonoBehaviour
{
    public GameObject Incorrect_pic;
    public GameObject Correct_pic;
    public GameObject back_button;
    public GameObject next_button;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;



    async void Start()
    {
        Debug.Log("Time is ticking");
        if (MainScript.CallVarible.Timer_Reset == true || MainScript.CallVarible.CurrentlyOnScene == 0)
        {
            MainScript.CallVarible.Timer_Reset = false;
            MainScript.CallVarible.Timer = 600;
            MainScript.CallVarible.StopTheTimer = false;
            Debug.Log("Start");
        }
        while (MainScript.CallVarible.Timer > 0)
        {
            // Debug.Log("tick" + MainScript.CallVarible.Timer);
            if (MainScript.CallVarible.StopTheTimer == true)
            {
                break;
            }
            await Task.Delay(1000);
            if (MainScript.CallVarible.StopTheTimer == true)
            {
                break;
            }
            MainScript.CallVarible.Timer--;
            Debug.Log("Tick : " + MainScript.CallVarible.Timer);
        }
        if (MainScript.CallVarible.Timer <= 0 )
        {
            gotoScene(0);
        }
    }

    async public void next_scene()
    {
        if (MainScript.CallVarible.no_double_self_destuct == true)
        {
            MainScript.CallVarible.no_double_self_destuct = false;
        }
        else
        {
            self_destruct();
        }

        if (MainScript.CallVarible.CurrentlyOnScene == 1 && MainScript.CallVarible.quiz_done[0] == true)
        {
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene += 2;
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 3 && MainScript.CallVarible.quiz_done[1] == true)
        {
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene += 2;
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 5 && MainScript.CallVarible.quiz_done[2] == true)
        {
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene += 2;
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 7 && MainScript.CallVarible.quiz_done[3] == true)
        {
            MainScript.CallVarible.CurrentlyOnScene += 2;
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 9 && MainScript.CallVarible.quiz_done[4] == true)
        {
            MainScript.CallVarible.CurrentlyOnScene += 2;
        }else if (MainScript.CallVarible.CurrentlyOnScene == 11 && MainScript.CallVarible.quiz_done[5] == true)
        {
            MainScript.CallVarible.CurrentlyOnScene += 2;
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 13 && MainScript.CallVarible.quiz_done[6] == true)
        {
            MainScript.CallVarible.CurrentlyOnScene += 2;
        }
        else
        {
            MainScript.CallVarible.CurrentlyOnScene++   ;
            Debug.Log("next_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        
        MainScript.CallVarible.StopTheTimer = true;
        await Task.Delay(250);
        SceneManager.LoadScene(MainScript.CallVarible.CurrentlyOnScene);
        MainScript.CallVarible.Timer_Reset = true;
        Debug.Log("Scene :  " + MainScript.CallVarible.CurrentlyOnScene);
    }
    async public void back_scene()
    {
        if (MainScript.CallVarible.no_double_self_destuct == true)
        {
            MainScript.CallVarible.no_double_self_destuct = false;
        }
        else
        {
            self_destruct();
        }
        
        if (MainScript.CallVarible.CurrentlyOnScene == 3 && MainScript.CallVarible.quiz_done[0])
        {
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene -= 2;
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 5 && MainScript.CallVarible.quiz_done[1])
        {
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene -= 2;
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 7 && MainScript.CallVarible.quiz_done[2])
        {
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
            MainScript.CallVarible.CurrentlyOnScene -= 2;
            Debug.Log("back_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 9 && MainScript.CallVarible.quiz_done[3])
        {
            MainScript.CallVarible.CurrentlyOnScene -= 2;
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 11 && MainScript.CallVarible.quiz_done[4])
        {
            MainScript.CallVarible.CurrentlyOnScene -= 2;
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 13 && MainScript.CallVarible.quiz_done[5])
        {

            MainScript.CallVarible.CurrentlyOnScene -= 2;
        }
        else if (MainScript.CallVarible.CurrentlyOnScene == 15 && MainScript.CallVarible.quiz_done[6])
        {
            MainScript.CallVarible.CurrentlyOnScene -= 2;
        }
        else 
        {
            MainScript.CallVarible.CurrentlyOnScene--;
        }
        
        MainScript.CallVarible.StopTheTimer = true;
        await Task.Delay(250);
        SceneManager.LoadScene(MainScript.CallVarible.CurrentlyOnScene);
        MainScript.CallVarible.Timer_Reset = true;
        Debug.Log("Scene :  " + MainScript.CallVarible.CurrentlyOnScene);

    }
    public async void wrong_answer()
    {
        self_destruct();
        MainScript.CallVarible.no_double_self_destuct = true;
        Debug.Log(MainScript.CallVarible.CurrentlyOnScene);

        await show_incorrect_pic();
        back_scene();
    }
    public static void gotoScene(int ToScene)
    {
        MainScript.CallVarible.CurrentlyOnScene = ToScene;
        Debug.Log("goto_scene :   " + MainScript.CallVarible.CurrentlyOnScene);
        SceneManager.LoadScene(MainScript.CallVarible.CurrentlyOnScene);
    }
    public async void correct_asnwer()
    {
        self_destruct();
        MainScript.CallVarible.no_double_self_destuct = true;
        if (MainScript.CallVarible.CurrentlyOnScene == 2)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[0] = true;
            next_scene();
        } else if (MainScript.CallVarible.CurrentlyOnScene == 4) {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[1] = true;
            next_scene();
        } else if (MainScript.CallVarible.CurrentlyOnScene == 6)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[2] = true;
            next_scene();
        } else if (MainScript.CallVarible.CurrentlyOnScene == 8)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[3] = true;
            next_scene();
        } else if (MainScript.CallVarible.CurrentlyOnScene == 10)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[4] = true;
            next_scene();

        } else if (MainScript.CallVarible.CurrentlyOnScene == 12)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[5] = true;
            next_scene();
        } else if (MainScript.CallVarible.CurrentlyOnScene == 14)
        {
            await show_correct_pic();
            MainScript.CallVarible.quiz_done[6] = true;
            next_scene();
        }

    }

    public async Task show_correct_pic()
    {
        Correct_pic.SetActive(true);
        await Task.Delay(150);
        Correct_pic.SetActive(false);
        await Task.Delay(150);
        Correct_pic.SetActive(true);
        await Task.Delay(2500);
        Correct_pic.SetActive(false);
    }
    public async Task show_incorrect_pic()
    {
        Incorrect_pic.SetActive(true);
        await Task.Delay(150);
        Incorrect_pic.SetActive(false);
        await Task.Delay(150);
        Incorrect_pic.SetActive(true);
        await Task.Delay(2500);
        Incorrect_pic.SetActive(false);
    }
    public void self_destruct()
    {
        MainScript.CallVarible.StopTheTimer = true;
        Destroy(this.answer1);
        Destroy(this.answer2);
        Destroy(this.answer3);
        Destroy(this.back_button);
        Destroy(this.next_button);

    }
    

}
