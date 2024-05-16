using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptButton : MonoBehaviour
{

    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
