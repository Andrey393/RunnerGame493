using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.name == "Hero" )
        {
            animator.SetBool ( "PlayerNearby", true );
        }
    }
}
