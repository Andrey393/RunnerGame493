using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void ESC ( )
    {
        gameObject.SetActive ( true ); 
       
    }
    public void ResumeButton ( )
    {
        Time.timeScale = 1;
        Invoke ( "Timer", 2 );
    }
    void Timer ( )
    {
        Time.timeScale = 1;
    }
    public void RestarButton ( )
    {

        SceneManager.LoadScene ( "SampleScene" );

    }

    public void MenuButton ( )
    {

        SceneManager.LoadScene ( "Menu" );
    }
}
