using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    [SerializeField] private AudioSource clickPlay;
    [SerializeField] private AudioSource clickButton;

    public void ButtonSoundClickPlay ( )
    {
        clickPlay.Play ( );
    }
    public void ButtonSoundClick ( )
    {
        clickButton.Play ( );
    }
}
