using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float rotSpeed = 20;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [System.Obsolete]
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        
        transform.RotateAround(Vector3.up, -rotX);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
