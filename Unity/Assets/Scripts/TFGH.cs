using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class TFGH : MonoBehaviour
{
    public InputField Nam1, Nam2, Nam3, Nam4;
    public string char1, char2, char3, char4;
    public Text signup;

    public void Start()
    {
        signup.text = "";
    }

    public void OnSubmit()
    {
        char1 = Nam1.text;
        char2 = Nam2.text;
        char3 = Nam3.text;
        char4 = Nam4.text;


        //Comment these later
        Debug.Log("First Name:" + char1);
        Debug.Log("Last Name:" + char2);
        Debug.Log("Phone no" + char3);
        Debug.Log("Password" + char4);
        StartCoroutine(CreateUser(char1, char2, char3, char4));


    }



    IEnumerator CreateUser(string fname, string lname, string phoneno, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("fnamePost", fname);
        form.AddField("lnamePost", lname);
        form.AddField("pnoPost", phoneno);
        form.AddField("passPost", pass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/uni2d/InsertUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                print(www.downloadHandler.text);
                Debug.Log("Success");
                signup.text = "Sign up successful!";

            }
        }
    }
}