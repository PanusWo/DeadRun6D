using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button_Start()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Button_Credit()
    {
        SceneManager.LoadScene("groupcredit");
    }

    public void Button_Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Button_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
