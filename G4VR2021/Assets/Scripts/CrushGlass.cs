using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGlass : MonoBehaviour
{
    AudioSource Glass;
    public int Hp=30;
    // Start is called before the first frame update
    void Awake()
    {
        Hp=30;

    }
    void start()
    {
        Glass= GetComponent<AudioSource>();
        Glass.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp<=0)
        {
            Glass.Play();
            Debug.Log("Glass crushed");
            Destroy(gameObject);
        }
    }
}
