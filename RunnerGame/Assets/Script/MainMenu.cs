using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    ReadJSON readJSON;
    public PlayableDirector animationBackround;
    public void Start ( )
    {
        //ReadJSON.LoadFromJSON ( );
    }
    public void PlayGame ( )
    {
        animationBackround.Play ( );
        Invoke ( "Play", 2.5f );

       
    }
  
    void Play ( )
    {
        SceneManager.LoadScene ( SceneManager.GetActiveScene ( ).buildIndex + 1 );
    }
    public void QuitGame ( )
    {
        Debug.Log ( "Выход!" );
        Application.Quit ( );
    }
}
