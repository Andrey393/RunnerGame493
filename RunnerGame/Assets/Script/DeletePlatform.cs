using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlatform : MonoBehaviour
{
    [SerializeField] private GameObject Object;

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.name == "Hero" )
        {
           
            Destroy ( Object );
        }
    }
}
