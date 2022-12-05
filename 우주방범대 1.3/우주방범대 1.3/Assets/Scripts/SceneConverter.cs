using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scene
{
    MAIN, SELECT, SET
}

public class SceneConverter : MonoBehaviour
{
    public Scene _moveTo;
    StageList stageList;

    public void SceneMove()
    {
        stageList = FindObjectOfType<StageList>();
        stageList.StopThisBGM();
        switch (_moveTo)
        {
            case Scene.MAIN:
                SceneManager.LoadScene("Main");
                break;
            case Scene.SELECT:
                SceneManager.LoadScene("Select");
                break;
            case Scene.SET:
                SceneManager.LoadScene("Set");
                break;
        }
    }
}
