using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject inGameSettings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenuHandler()
    {
        inGameMenu.SetActive(false);
    }

    public void RestartHandler()
    {
        SceneManager.LoadScene("IT7030C-Final-Project");
    }

    public void QuitHandler()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
