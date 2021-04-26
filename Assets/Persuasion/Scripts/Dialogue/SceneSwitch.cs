using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField]
    public int LevelNumber;
    public void SwitchScene()
    {
        SceneManager.LoadScene(LevelNumber);
    }
}
