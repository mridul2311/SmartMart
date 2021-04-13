using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using System;

public class mouseover : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI hey;
     String1 t=new String1();
     
     void Start()
   {
       hey.text="Price";
   }
	 
    void OnMouseDown()
    {

        int n;
    bool isNumeric = int.TryParse(gameObject.tag, out n);
     if(isNumeric)  
       {
           int PID=Int32.Parse(gameObject.tag);
       StartCoroutine(pro(PID));
       }
    
    }
     IEnumerator pro(int pid)
    {
       
     WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/uni2d/bill.php", form))
        {

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
               string line=www.downloadHandler.text;
               
                t.cart = line.Split('|').ToList();
                hey.text=t.cart[2];
                          
            }
        }
        
    }
    void OnMouseUp()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        hey.text="";
    }
    void Update()
    {
        
    }
}
