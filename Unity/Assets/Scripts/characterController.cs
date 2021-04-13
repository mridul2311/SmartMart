using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
	public float speed = 5.0F;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical")*speed;
	float straffe= Input.GetAxis("Horizontal")*speed;
	translation *= Time.deltaTime;
	straffe *= Time.deltaTime;
	
	transform.Translate(straffe,0,translation);
	
		
		
       

  
    }
}
