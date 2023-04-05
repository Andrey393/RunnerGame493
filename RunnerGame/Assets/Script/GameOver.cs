using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class GameOver : MonoBehaviour
{
    private ReadJSON saveToJSON;
    [SerializeField] private TMP_Text GlassesText;
    [SerializeField] private CinemachineVirtualCamera camera;
    public Hero hero;
    public bool popypka = false;
    int glasses;
    public void Start ( )
    {
        RandomCoint ( );
    }
    void RandomCoint ( )
    {
        int coint = Random.Range ( 0, Hero.glasses + 5 );
        int desvie = Random.Range ( 1, 2 );
        if ( desvie == 1 && Hero.glasses>0 )
        {
            glasses = Hero.glasses - coint;
        }
        else
        {
            glasses = Hero.glasses + coint;
        }
        
    }
    public void Setup()
    {
        

        gameObject.SetActive( true );
        if( popypka )
        {
            GlassesText.text="X";
        }
        else
        {
            GlassesText.text = glasses.ToString ( );
        }
        
        
    }
    public void ResumeButton ( )
    {
        
        if( Hero.glasses >= glasses && popypka == false)
        {
            Hero.glasses -= glasses;
            if ( Hero.glasses >= 0 )
            {
                Hero.healt += 1;
                hero.Respawn ( );
                camera.Follow = hero.transform;
                RandomCoint ( );
                popypka = true;
            }
        }
        
       
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
