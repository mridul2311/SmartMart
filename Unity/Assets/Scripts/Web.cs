using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
//using Valve.VR.InteractionSystem.Sample;
//using VRKeys;

class Pos
{
    public int x;
    public int y;
    public Pos()
    {
        x = -1;
        y = 0;
    }
}


public class Web : MonoBehaviour
{
    public static bool a_flag = false;
    public static AssetBundle bundle;
    int shelf = -1;
    Pos[] pos = new Pos[8];
    GameObject[] shelfs = new GameObject[2];

    public void Start()
    {
        for(int i=0;i<2;i++)
        {
            shelfs[i] = GameObject.Find("Shelf" + (i + 1));

        }
        
    }

    public IEnumerator UpdateInventory(int pid)
    {
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        //Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/updateInventory.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }
            else
            {
                string error = www.downloadHandler.text;
                
                int ecode = System.Convert.ToInt32(error);
                if (ecode == 1)
                {
                    Debug.Log("Out of Stock");
                }

                else
                {
                   // Debug.Log("Pro");
                }
            }
        }
    }

    public IEnumerator CheckStock(int pid, String1 details, MonoBehaviour obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/checkStock.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                details.s = www.downloadHandler.text;
                Debug.Log(details.s);
            }

            print("This is stockZero: " + details.s);
            string[] strlist = details.s.Split(',');
            //obj.stock



            Scene currentScene = SceneManager.GetActiveScene();
            string scene = currentScene.name;

            if (details.s.StartsWith("No results") || (int.Parse(strlist[4]) == 0 && scene.Equals("SampleScene1")))
            {   print("deac");
                obj.gameObject.SetActive(false);
            }
        }
    }

    public IEnumerator GetAddress(string phone, String1 details)//, Address a)
    {
        WWWForm form = new WWWForm();
        form.AddField("phone", phone);
        print("I am in Web for address");
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/checkAddress.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                details.s = www.downloadHandler.text;
                Debug.Log(details.s);
                //a.ShowinPanel();
            }
        }
    }

    public IEnumerator GenerateBill(string phone, string aid, Dictionary<int, Product> items, float total)//, Confirm c
    {
        String1 details = new String1();
        WWWForm form = new WWWForm();
        //float total = 0; 

        int[] quantity = new int[items.Count];
        float[] prices = new float[items.Count];
        int i = 0;
        print(total);
        form.AddField("phone", phone);
        form.AddField("aid", aid);
        foreach (var x in items.Keys)
        {
            //total += items[x].getTotalAmount();

            quantity[i] = items[x].getQuantity();
            prices[i++] = items[x].getTotalAmount();
           
        }
        print(String.Join(",", items.Keys));
        form.AddField("pids", String.Join(",", items.Keys));
        form.AddField("total", Convert.ToString(total));
        form.AddField("quantities", String.Join(",", quantity));
        form.AddField("prices", String.Join(",", prices));
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/NewBill.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                details.s = www.downloadHandler.text;
                Debug.Log(details.s);
                //c.Show(details);
            }
        }

    }

    public IEnumerator GetStock(int pid)
    {
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/updateInventory.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                int ecode = int.Parse(www.downloadHandler.text);

                Debug.Log("GetStock: " + ecode);
                /*if (ecode == 1)
                {
                    obj.PlusError();
                    GameObject stockmsg = GameObject.Find("Out of Stock");
                    stockmsg.transform.localScale = new Vector3(1f, 1f, 1f);
                    yield return new WaitForSeconds(3f);
                    stockmsg.transform.localScale = new Vector3(0f, 0f, 0f);
                }

                else
                    obj.PlusPlus();
		*** Include your code here
		*/ 
            }

        }
    }

    public IEnumerator GetCustomer_Phone(string phone_no, string pwd)//, DemoScene d)
    {
        String1 details = new String1();
        WWWForm form = new WWWForm();
        form.AddField("phone", phone_no);
        form.AddField("pwd", pwd);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getCustomer_Phone.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                details.s = www.downloadHandler.text;
                Debug.Log(details.s);
                //d.ValidateEmailReally(details, phone_no);
            }

        }
    }


    public IEnumerator GetCustomer_Name(List<int> cids, String1 reviews)
    {
        print("In Customer name");
        string details;
        WWWForm form = new WWWForm();

        print(String.Join(",", cids));
        form.AddField("cids", String.Join(",", cids));
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getCustomer.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error in names");
            }
            else
            {
                details = www.downloadHandler.text;
                Debug.Log("Details of names: " + details);
                string[] names = details.Split(',');
                for (int i = 0; i < cids.Count; i++)
                {
                    reviews.s = reviews.s.Replace("`" + cids[i].ToString() + "`", names[i]);
                }
                reviews.s = reviews.s.Replace("\n", "\n\n");
                print("Final Reviews: " + reviews.s);

            }

        }
    }

    public IEnumerator UpdateInventoryMinus(int pid)
    {
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/IncStock.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }
            else
            {
                string error = www.downloadHandler.text;
                print(error);

                int ecode = System.Convert.ToInt32(error);
                if (ecode == 1)
                {
                    Debug.Log("Cannot update Stock");
                }

                else
                {
                    Debug.Log("No Error");
                }
            }
        }
    }

    public IEnumerator UpdateInventoryCount(int pid, int count)
    {
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        form.AddField("count", count);
        Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/IncStockCount.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }
            else
            {
                string error = www.downloadHandler.text;
                print(error);

                int ecode = System.Convert.ToInt32(error);
                if (ecode == 1)
                {
                    Debug.Log("Cannot update Stock");
                }

                else
                {
                    Debug.Log("No Error");
                }
            }
        }
    }
    public IEnumerator getRec(int pid, String1 rec)
    {
        print("I am in getRec");
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        //form.AddField("cid", cid);
        form.AddField("name", "Manoj");
        Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getRecommendation.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }

            string msg = www.downloadHandler.text;
            string[] msgs = msg.Split('|');
            print("RecPids: " + msgs[0]);
            foreach(string s in msgs[0].Split(',')) {
                int num;
                if (int.TryParse(s, out num));
                   // obj.recpids.Add(num);
            }
            rec.s = msgs[1].Substring(0, msgs[1].Length - 1);
            print("Python php Recommendation: " + msg);
            

           // obj.showRec();
        }
    }

    public IEnumerator getRec1(int pid, String1 rec)
    {
        print("I am in getRec");
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        //form.AddField("cid", cid);
        form.AddField("name", "Manoj");
        Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getRecommendation1.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }

            string msg = www.downloadHandler.text;
            string[] msgs = msg.Split('|');
            print("RecPids: " + msgs[0]);
            foreach (string s in msgs[0].Split(','))
            {
                int num;
                if (int.TryParse(s, out num)) ;
                // obj.recpids.Add(num);
            }
            rec.s = msgs[1].Substring(0, msgs[1].Length - 1);
            print("Python php Recommendation: " + msg);


            // obj.showRec();
        }
    }



    public IEnumerator getRec2(int pid, String1 rec)
    {
        print("I am in getRec");
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        //form.AddField("cid", cid);
        form.AddField("name", "Manoj");
        Debug.Log(pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getRecommendation2.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }

            string msg = www.downloadHandler.text;
            string[] msgs = msg.Split('|');
            print("RecPids: " + msgs[0]);
            foreach (string s in msgs[0].Split(','))
            {
                int num;
                if (int.TryParse(s, out num)) ;
                // obj.recpids.Add(num);
            }
            rec.s = msgs[1].Substring(0, msgs[1].Length - 1);
            print("Python php Recommendation: " + msg);


            // obj.showRec();
        }
    }



    public IEnumerator getShelf(int pid)
    {
        print("I am in getShelf with pid"+pid);
        WWWForm form = new WWWForm();
        form.AddField("pid", pid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getShelf.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }

            string msg = www.downloadHandler.text;
            print("Shelfno: " + msg);
            if(!msg.StartsWith("!!Error"))
                shelf = int.Parse(msg);
        }
    }

    public IEnumerator GetText()
    {
        print("I am in GetText()");
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle("http://localhost/NUP/mymodel/productbundle"))
        {
            yield return uwr.SendWebRequest();
            print("In Co routine");
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                print(bundle);

                List<Hash128> listOfCachedVersions = new List<Hash128>();
                Caching.GetCachedVersions(bundle.name, listOfCachedVersions);

                foreach (var x in listOfCachedVersions)
                {
                    print("Cache list: " + x.ToString());
                }

                if (bundle == null)
                    print("Null bundle");

                Main.Instance.PanelE();

                //GameObject obj = Instantiate(bundle.LoadAsset("PREF_food_04"), Vector3.zero, Quaternion.identity) as GameObject;
                UnityEngine.Object[] objs = bundle.LoadAllAssets();
                for (int i = 0; i < 8; i++)
                    pos[i] = new Pos();
                foreach(var obj in objs)
                {
                    GameObject jon = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
                    string spid = Regex.Match(jon.name, @"\d+").Value;
                    StartCoroutine(getShelf(int.Parse(spid)));
                    while (shelf == -1)
                        yield return new WaitForSeconds(0.001f);


                    for(int i=0;i<2;i++)
                    {
                        if ((i + 1) != shelf)
                            shelfs[i].SetActive(false);
                        else
                            shelfs[i].SetActive(true);
                            
                    }

                    if (pos[shelf - 1].x >= 5)
                    {
                        pos[shelf - 1].y++;
                        pos[shelf - 1].x = 0;
                    }                        
                    else
                        pos[shelf - 1].x++;
                    string name = "("+shelf+","+pos[shelf-1].x+","+pos[shelf-1].y+")";
                    print("Shelf magic: " + name);

                    if (shelf==2||shelf==1) //|| name.Equals("(2,2,0)") || name.Equals("(2,3,0)"))
                    {
                        name = "(" + pos[shelf - 1].x + "," + pos[shelf - 1].y + ")";
                        jon.transform.position = GameObject.Find(name).transform.position;
                        jon.tag = "Hell";
                        jon.transform.parent = GameObject.Find(name).transform;
                        pos[shelf - 1].x++;


                        name = "(" + pos[shelf - 1].x + "," + pos[shelf - 1].y + ")";
                        print("Shelf magic: " + name);
                        jon = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
                        jon.transform.position = GameObject.Find(name).transform.position;
                        jon.tag = "Hell";
                        jon.transform.parent = GameObject.Find(name).transform;
                        pos[shelf - 1].x++;


                        name = "(" + pos[shelf - 1].x + "," + pos[shelf - 1].y + ")";
                        print("Shelf magic: " + name);
                        jon = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
                        jon.transform.position = GameObject.Find(name).transform.position;
                        jon.tag = "Hell";
                        jon.transform.parent = GameObject.Find(name).transform;


                        shelf = -1;

                    }
                    else
                    {
                        jon.transform.position = GameObject.Find("Cookies1").transform.position;
                        jon.tag = "Hell";
                        pos[shelf - 1].x++;
                        jon = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
                        jon.transform.position = GameObject.Find("Cookies2").transform.position;
                        jon.tag = "Hell";
                        pos[shelf - 1].x++;
                        jon = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
                        jon.transform.position = GameObject.Find("Cookies3").transform.position;
                        jon.tag = "Hell";
                        shelf = -1;
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    shelfs[i].SetActive(true);

                }
                //DontDestroyOnLoad(obj);


                /*obj.transform.position = GameObject.Find("Cookies1").transform.position;
                obj.tag = "Hell";

                //DontDestroyOnLoad(obj);
                obj = Instantiate(bundle.LoadAsset("PREF_food_04"), Vector3.zero, Quaternion.identity) as GameObject;


                obj.transform.position = GameObject.Find("Cookies2").transform.position;
                obj.tag = "Hell";
                //DontDestroyOnLoad(obj);
                obj = Instantiate(bundle.LoadAsset("PREF_food_04"), Vector3.zero, Quaternion.identity) as GameObject;


                obj.transform.position = GameObject.Find("Cookies3").transform.position;
                obj.tag = "Hell";
                //DontDestroyOnLoad(obj);
                */

                Main.Instance.PanelD();

                //bundle.Unload(true);

                //uwr.Dispose();

                //obj.transform.position += new Vector3(1, 0, 0);
            }
        }


    }
    public IEnumerator getSec(string name)
    {
        print("I am in getSec");
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/NUP/getSection.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                //Debug.Log(www.error);
            }

            string msg = www.downloadHandler.text;
            msg = "2";
            //result = new String1("TeleportPoint" + msg);
            GameObject des = GameObject.FindGameObjectWithTag("TP"+msg);
            if (des == null)
                print("Des is null");
            GameObject player = GameObject.Find("Player");
            if (player == null)
                print("Player is null");
            player.transform.position = des.transform.position;
        }
    }

}
