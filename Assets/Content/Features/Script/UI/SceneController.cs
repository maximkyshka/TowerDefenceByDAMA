
 using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName) && SceneManager.GetSceneByName(sceneName).IsValid())
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " does not exist or name is invalid!");
        }
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Scene index " + sceneIndex + " is out of range!");
        }
    }
}

