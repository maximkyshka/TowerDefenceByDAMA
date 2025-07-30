using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField, Range(1, 3)] private int _level;
    
    public void GameOver()
    {
        SceneManager.LoadScene(_level);
    }

    public void GameWin()
    {
        PlayerPrefs.SetInt("Level", _level + 1);
        SceneManager.LoadScene(_level == 3 ? 0 : _level + 1);
    }
}
