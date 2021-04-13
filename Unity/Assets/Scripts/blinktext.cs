using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class blinktext : MonoBehaviour
{
    public TextMeshProUGUI t;
    public TextMeshProUGUI t1;
    // Start is called before the first frame update
    void Start()
    {
        t.text="ALSO BUY";
        t1.text = "Hot deals!";
        StartBlinking();
    }
    IEnumerator Blink()
    {
        while (true)
        {
            t.text = "ALSO BUY!";
            t1.text = "Hot deals!";
            yield return new WaitForSeconds(0.5f);
            t.text = "";
            t1.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    
    }

    void StartBlinking(){
        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}