using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var Glass=other.gameObject.GetComponent<BreakGlass>();
        if (Glass == null)
        {
            return;
        }
        Glass.Hp -= 10;
        
    }
}
