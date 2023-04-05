using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glasses : MonoBehaviour
{

    [SerializeField] private AudioSource glassesSound;
    [SerializeField] private SpriteRenderer coinSpriteRenderer;
    [SerializeField] private Light2D light;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            
            if (Hero.baffMonetCouint > 0 )
            {
                Hero.glasses += 1 * Hero.baffMonetCouint;    
            }
            else
            {
                Hero.glasses++;
            }
            glassesSound .Play ();
            light.intensity = 0;
            coinSpriteRenderer.color = new Color ( 1f, 1f, 1f, 0f );  // Делает объект невидимым
            Invoke ( "DestroyCoin", glassesSound.clip.length ); // Уничтожает объект спустя время 
        }
    }

    private void DestroyCoin ( )
    {
        Destroy ( gameObject );
    }
}

