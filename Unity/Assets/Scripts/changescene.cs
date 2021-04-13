using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class changescene : MonoBehaviour
{
    // Start is called before the first frame update
    public void change(string a)
    {
        Application.LoadLevel(a);
    }
}
