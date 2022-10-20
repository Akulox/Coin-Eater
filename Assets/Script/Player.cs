using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Vector3> path;
    public float speed;

    private void Update()
    {
        if (path.Count > 0)
        {
            var step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, path[0], step);
        
            if (Vector3.Distance(transform.position, path[0]) < 0.001f)
            {
                path.RemoveAt(0);
            }
        }
    }
}
