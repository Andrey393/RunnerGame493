using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baff : MonoBehaviour
{
    
    public GameObject nameObject;

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        
        string name  = nameObject.tag;
        if ( collision.tag == "Player" )
        {
            switch ( name )
            {
                case "HealtBaff": 
                    Hero.healt++;                 
                    break;

                case "SilaBaff":
                    Hero.baffMonet += 250f;
                    Hero.baffMonetCouint++;
                    break;
                case "PoletBaff":
                    Hero.baffPolit = 150f;
                    break;

            }    
            Destroy ( gameObject );
        }
    }
}
