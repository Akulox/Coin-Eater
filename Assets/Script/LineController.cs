using System;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lr;
    public Player player;


    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
        
    }

    private void ClearLines()
    {
        _lr.positionCount = 0;
    }

    private void Update()
    {
        if (player)
        {
            _lr.positionCount = player.path.Count + 1;
            _lr.SetPosition(0, player.transform.position - Vector3.back);
            for (int i = 0; i < player.path.Count; i++)
            {
                _lr.SetPosition(i+1, player.path[i] - Vector3.back);
            }
        }
        else
        {
            ClearLines();
        }
    }
}
