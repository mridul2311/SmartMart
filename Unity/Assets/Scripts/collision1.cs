using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class collision1 : MonoBehaviour
{  public Rigidbody r;
    public static int c=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
private void OnTriggerEnter(Collider hit) {
 
    if(hit.tag == "100")
    {
   
        r.isKinematic = true;
        c++;
        print("count"+c);
    
    }
   
}
 private void OnTriggerExit(Collider hit) {
 
    if(hit.tag == "100")
    {
   
        r.isKinematic = false;
        c--;
        print("count"+c);
    
    }
   
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
