/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;


public class String1
{
    public string s;
    public String1() { s = null; }
    public String1(string s)
    {
        this.s = s;
    }
}
public class Main : MonoBehaviour
{
	public static Main Instance;
    static GameObject panel, addtocart, revPanel, recPanel;

    public Web Web;
    void Awake()
    {
        SteamVR.Initialize(true);
        Instance = this;
		Web = GetComponent<Web>();

        Object prefab = Resources.Load(@"/Prefabs/AddressButtonB", typeof(Button));

        if (prefab == null)
            print("The prefab is null in main");

        panel = GameObject.Find("DescPanel");
     
        addtocart = GameObject.Find("AddtoCartPanel");

        revPanel = GameObject.Find("ReviewPanel");     

        recPanel = GameObject.Find("RecPanel");

    }

    private void Start()
    {
        PanelD();
        //StartCoroutine(Instance.Web.getSec("Cookie"));
        //-StartCoroutine(Main.Instance.Web.getRec(1, 1));
    }

    public void PanelE()
    {      
        panel.SetActive(true);
       
        addtocart.SetActive(true);
       
        revPanel.SetActive(true);

        recPanel.SetActive(true);

        print("I am in PanelE of Main");
    }

    public void PanelD()
    {
        panel.SetActive(false);

        addtocart.SetActive(false);

        revPanel.SetActive(false);

        recPanel.SetActive(false);

        print("I am in PanelD of Main");
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Valve.VR;


public class String1
{
    public string s;
    public float rate;public float stock;
    public List<string> cart = new List<string>();
    public Dictionary<int, int> shop = new Dictionary<int, int>();
    public Dictionary<int, Product> items = new Dictionary<int, Product>();
    public String1() { s = null;rate=0; }
    public String1(string s)
    {
        this.s = s;
    }
    public String1(float rate)
    {
        this.rate=rate;
    }
}
public class Main : MonoBehaviour
{
	public static Main Instance;
    static GameObject panel, addtocart, revPanel, recPanel;

    public Web Web;
    void Awake()
    {
        //SteamVR.Initialize(true);
        Instance = this;
		Web = GetComponent<Web>();

        Object prefab = Resources.Load(@"/Prefabs/AddressButtonB", typeof(Button));

        if (prefab == null)
            print("The prefab is null in main");

        //panel = GameObject.Find("DescPanel");
     
        //addtocart = GameObject.Find("AddtoCartPanel");

        //revPanel = GameObject.Find("ReviewPanel");     

        //recPanel = GameObject.Find("RecPanel");

    }

    private void Start()
    {
        //PanelD();
        //StartCoroutine(Instance.Web.getSec("Cookie"));
        //-StartCoroutine(Main.Instance.Web.getRec(1, 1));
    }

    public void PanelE()
    {      
        panel.SetActive(true);
       
        addtocart.SetActive(true);
       
        revPanel.SetActive(true);

        recPanel.SetActive(true);

        print("I am in PanelE of Main");
    }

    public void PanelD()
    {
        panel.SetActive(false);

        addtocart.SetActive(false);

        revPanel.SetActive(false);

        recPanel.SetActive(false);

        print("I am in PanelD of Main");
    }
}
