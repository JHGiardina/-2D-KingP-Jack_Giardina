using UnityEngine;
using UnityEditor;
using System.Collections;

public class Menu_Behavior : MonoBehaviour
{

    public void gotoGame()
    {
        StartCoroutine(WaitForSoundAndTransition("Main_Game"));
    }

    public void gotoMenu()
    {
        StartCoroutine(WaitForSoundAndTransition("Main_Menu"));
    }

    public void quitGame() //GPTo3MH
    {    
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif 
        
    }

    public void gotoPins(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pin_Select");

    }
    private IEnumerator WaitForSoundAndTransition(string sceneName)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
