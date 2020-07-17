using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static class CallVarible
    {
        public static int CurrentlyOnScene;
        public static bool[] quiz_done = new bool[10] { false, false, false, false, false, false, false, false, false, false  };
        public static int Timer = 300;
        public static bool Timer_Reset = true;
        public static bool StopTheTimer = false;
        public static bool no_double_self_destuct = false;


    }
    void Start()
    {
        CallVarible.CurrentlyOnScene = 0;
    }
    void Update()
    {
        if (MainScript.CallVarible.CurrentlyOnScene == 0)
        {
            CallVarible.quiz_done = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        }
    }

    
}