using UnityEngine;
using UnityEngine.UI;

public class LevelButtonControl : MonoBehaviour
{
    int _level;
    
    public Button _buttonLevel1;
    public Button _buttonLevel2;
    public Button _buttonLevel3;
    
    void Start()
    {
        _level = PlayerPrefs.GetInt("Level");
        _buttonLevel1.interactable = _level >= 1;
        _buttonLevel2.interactable = _level >= 2;
        _buttonLevel3.interactable = _level >= 3;
    }
}
