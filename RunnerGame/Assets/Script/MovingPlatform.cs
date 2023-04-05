
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int startinPoint;
    [SerializeField] private Transform [] point;

    private int i;
    private void Start ( )
    {
        transform.position = point [startinPoint].position;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, point [i].position) < 0.02f )
        {
            i++;
            if(i== point.Length)
            {
                i = 0;
            }
        }
     
        transform.position = Vector2.MoveTowards(transform.position,point [i].position, speed *Time.deltaTime);
    }
}
