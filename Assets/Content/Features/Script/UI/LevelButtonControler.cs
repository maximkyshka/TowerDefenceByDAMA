using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonControler : MonoBehaviour
{
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;

    private int _level;

    private void Start()
    {
        _level = PlayerPrefs.GetInt("Level", 1);

        if(_level1Button != null) _level1Button.gameObject.SetActive(_level >= 1);
        if(_level2Button != null) _level2Button.gameObject.SetActive(_level >= 2);
        if(_level3Button != null) _level3Button.gameObject.SetActive(_level >= 3);

        if(_level1Button != null) _level1Button.onClick.AddListener(() => LoadSceneByIndex(1));
        if(_level2Button != null) _level2Button.onClick.AddListener(() => LoadSceneByIndex(2));
        if(_level3Button != null) _level3Button.onClick.AddListener(() => LoadSceneByIndex(3));
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