using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Transform laserPosition;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        LineRenderer.SetPosition(0, laserPosition.position);
        if (hit)
        {
            LineRenderer.SetPosition(1,hit.point);
        }
        else
        {
            LineRenderer.SetPosition(1,transform.right*100);
        }
        
    }
}
