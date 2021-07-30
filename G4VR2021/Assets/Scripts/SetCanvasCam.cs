using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasCam : MonoBehaviour
{
    Camera VRCam;
    // Start is called before the first frame update
    void Start()
    {
        VRCam = GameObject.FindWithTag("VRCam").GetComponent<Camera>();
        Canvas c = this.GetComponent<Canvas>();
        c.worldCamera = VRCam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
