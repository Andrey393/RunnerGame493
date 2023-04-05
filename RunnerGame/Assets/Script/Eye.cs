using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
 
    GameObject player;
    void Start()
    {
        player = GameObject.Find ( "Hero" );
    }
    private void Update ( )
    {
        Vector3 player3 = player.transform.position;

        Vector2 direction = new Vector2 ( player3.x - transform.position.x, player3.y - transform.position.y );
        transform.up = direction;
    }


}
