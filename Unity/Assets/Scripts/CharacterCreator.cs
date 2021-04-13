
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class CharacterCreator : MonoBehaviour
{

    public InputField Name1,Name2,Name3;
    public static string charName1,charName2,charName3;
    public static int i=0;
    public TextMeshProUGUI wrong;
    public TextMeshProUGUI success;

    public void Start()
    {
        wrong.text = "";
        success.text = "";
    }
    public void OnSubmit()
    {
         charName1 = Name1.text;
         charName2 = Name2.text;
           charName3 = Name3.text;
        StartCoroutine(Login(charName1,charName2,charName3));
        //Comment these later
        if (i == 1)
        {
            Debug.Log("My man");
        }//Till here
        //Use variables charName1 and charName2 to check in database
        
    }


    
    IEnumerator Login(string firstName,string lastName,string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginFName", firstName);
        form.AddField("loginLName", lastName);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/uni2d/getUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(www.downloadHandler.text.Contains("Login Success"))
                    {
                    i = 1;
                    wrong.text = "";
                    success.text = "Successful!";
                }
                else
                {
                    success.text = "Invalid Username or Password!";
                    
                    //success.text = "";
                }
                
            }
        }
    }

}
