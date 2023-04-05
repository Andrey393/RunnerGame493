using Cinemachine;
using UnityEngine;


public class Falling : MonoBehaviour
{
    private GameObject hero;
    private CinemachineVirtualCamera camera;
    private UnityEngine.Vector3 heroFallPosition;

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        hero = GameObject.FindWithTag ( "Player" );
        camera = GameObject.FindWithTag ( "Camera" ).GetComponent<CinemachineVirtualCamera> ( );

        if ( collision.tag == "Player" )
        {
            camera.Follow = null;         
            heroFallPosition = hero.transform.position;
            Hero.healt = 0;
            

        }
    }
 

    private void Update ( )
    {
        if( hero != null )
        {
            if ( camera.Follow == null )
            {

                camera.transform.position = new UnityEngine.Vector3 ( heroFallPosition.x + 5, heroFallPosition.y + 0.1f, heroFallPosition.z - 10f );
                
            }
        }
       
    }

}
