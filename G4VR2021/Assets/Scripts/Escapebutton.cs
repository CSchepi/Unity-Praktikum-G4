using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escapebutton : MonoBehaviour
{

    public GameObject LeaveCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscapePressed()
    {
        LeaveCube.gameObject.SetActive(false);
    }
}
