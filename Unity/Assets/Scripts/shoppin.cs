using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
//using UnityEngine.__Analytics__;
using UnityEngine.Analytics;


public class shoppin : CharacterCreator
{    
    public static float sum=0; 
    public TextMeshProUGUI bill;
    public TextMeshProUGUI recprod;
    public TextMeshProUGUI cusname;
    string _text;
    static int m=0;
    public static List<string> phone;
    String1 c=new String1();
    String1 pop = new String1();
    

    public TextMeshProUGUI hey1;
    public TextMeshProUGUI recprod1;

    void Start()
   {
      bill.text="";
        recprod1.text = "Hot deals!";
      recprod.text="Recommendations";
      hey1.text="";
        cusname.text = "";
        print(charName1);
        StartCoroutine(user_user());
        StartCoroutine(popularity());

    }

    IEnumerator user_user()
    {
        //print("reccomme");
        yield return StartCoroutine(Bill1());
        print(phone[0]);
        int numVal = Int32.Parse(phone[0]);
        StartCoroutine(rec(numVal));
    }

    IEnumerator popularity()
    {
        //print("reccomme");
        yield return StartCoroutine(Bill1());
        print(phone[0]);
        int numVal = Int32.Parse(phone[0]);
        StartCoroutine(rec2(numVal));
    }


    public void OnTriggerEnter(Collider other)
    {
        try
        {
            int n;
            bool isNumeric = int.TryParse(gameObject.tag, out n);
            if (isNumeric)
            {

                int PID = Int32.Parse(other.tag);


                if ((PID == 50) && (m == 0))
                {
                    StartCoroutine(Bill());
                    m = 1;
                }
                if (PID <= 37)

                {
                    StartCoroutine(Add(PID));
                    AnalyticsEvent.Custom("product_added", new Dictionary<string, object>
            {
                 {"product_id", PID},{"default","hello"}

            });
                    StartCoroutine(rec1(PID));
                    var xys = other.gameObject.transform;
                    xys.parent = transform;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
	
	}
     
	  public void OnTriggerExit(Collider other)
    {
        try
        {
            int n;
            bool isNumeric = int.TryParse(gameObject.tag, out n);
            if (isNumeric)
            {
             int PID = Int32.Parse(other.tag);
            if (PID <= 37)

                {
                    StartCoroutine(Subtract(PID));
                    AnalyticsEvent.Custom("product_removed", new Dictionary<string, object>
            {
                 {"product_id", PID},{"default","bye"}

            });
                    var xys = other.gameObject.transform;
                    xys.parent = null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }

    }
	
    IEnumerator Add(int pid)
	{	

        if (c.shop.ContainsKey(pid))
         {   
              //print("if");
              StartCoroutine(pro(pid));
             Product pr = new Product(pid,c.cart[1],c.rate, 0, 2);
             StartCoroutine(Main.Instance.Web.UpdateInventory(pid));
             sum=sum+c.rate;
             hey1.text=sum.ToString();
             c.items.Remove(pid);
                for (int i = 0; i <c.shop[pid]; i++)
                {
                    pr.Increment();
                }
                c.items.Add(pid, pr);
                c.shop[pid]++;
         }
        else
        {
			//print("else");
            c.shop.Add(pid, 1);
        
            StartCoroutine(Main.Instance.Web.UpdateInventory(pid));
             yield return StartCoroutine(pro(pid));

               // print("rate"+c.rate);
                //print("rate"+c.cart[1]);
                Product pr = new Product(pid,c.cart[1],c.rate, 0, 2);
		       sum=sum+c.rate;
               hey1.text=sum.ToString();
               c.items.Add(pid, pr);
        }
        
	}

     IEnumerator Subtract(int pid)
	{	

        if (c.shop.ContainsKey(pid))
         {   
             if(c.shop[pid]!=1)
            {
             print("if");
             StartCoroutine(Main.Instance.Web.UpdateInventoryMinus(pid));
             yield return StartCoroutine(pro(pid));
            Product pr = new Product(pid,c.cart[1],c.rate, 0, 2);
             sum=sum-c.rate;
              hey1.text=sum.ToString();
             c.items.Remove(pid);
             c.shop[pid]-=1;
             for (int i = 0; i <c.shop[pid]-1; i++)
             {
                pr.Increment();
             }
            c.items.Add(pid, pr);
            }
            else
            {
            StartCoroutine(Main.Instance.Web.UpdateInventoryMinus(pid));
             yield return StartCoroutine(pro(pid));
             sum=sum-c.rate;
              hey1.text=sum.ToString();
             c.items.Remove(pid);
            }               
         }    
	}
    
    IEnumerator pro(int pid)
    {
        //print("in pro");
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
               
                c.cart = line.Split('|').ToList();
                c.rate= float.Parse(c.cart[2]);
                          
            }
        }
        
    }
    IEnumerator rec(int PID)
    {
                
      
        yield return StartCoroutine(Main.Instance.Web.getRec(PID,c));  
		//print("reco"+c.s);
        recprod.text=c.s;
    }

    IEnumerator rec1(int PID)
    {


        yield return StartCoroutine(Main.Instance.Web.getRec1(PID, c));
        //print("reco"+c.s);
        recprod.text = c.s;
    }

    IEnumerator rec2(int PID)
    {


        yield return StartCoroutine(Main.Instance.Web.getRec2(PID, pop));
        //print("reco"+c.s);
        recprod1.text = pop.s;
    }

    IEnumerator Bill1()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginFName", charName1);
        form.AddField("loginLName", charName2);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/uni2d/bill1.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
               // print(www.downloadHandler.text);
                phone = www.downloadHandler.text.Split('|').ToList();
                print(phone[0]);

            }
        }
    }

    IEnumerator Bill()
    {
        yield return StartCoroutine(Bill1());
        print(phone[1]);
        yield return StartCoroutine(Main.Instance.Web.GenerateBill(phone[1],"9",c.items,sum));
        StartCoroutine(GetText());
    }

    public void Read(string path)
    {
        _text = File.ReadAllText(path);
    }
	
	IEnumerator GetText()
	{	
			string myFileName = @"Assets\Scripts\unit.txt";
		TextWriter tw = new StreamWriter(myFileName);
    
		UnityWebRequest www = UnityWebRequest.Get("http://localhost/NUP/uni2d/ItemsData.php");
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.Log(www.error);
		}
		else
		{
			string line=www.downloadHandler.text;
			 List<string> stringList = line.Split(';').ToList();
			foreach (string s in stringList)
   			 tw.WriteLine(s);
   			 tw.Close();
				Read("Assets/Scripts/unit.txt");
        	print(_text);
            hey1.text="";
        	bill.text = _text;
            cusname.text ="Customer ID: "+ phone[0]+"  Customer  Name: "+charName1+" "+charName2;

        }

	}
	
    
}