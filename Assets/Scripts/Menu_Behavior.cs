using UnityEngine;
using UnityEditor;

public class Menu_Behavior : MonoBehaviour
{
    public void gotoGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Game");
    }

    public void gotoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu");
    }

    public void quitGame() //GPTo3MH
    {    
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif 
        
    }
}
