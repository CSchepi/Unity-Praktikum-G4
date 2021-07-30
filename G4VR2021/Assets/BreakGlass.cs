using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    public AudioClip BreakingGlass;
    public ParticleSystem pars;
    public int Hp=30;
    // Start is called before the first frame update
    void Awake()
    {
        Hp=30;

    }
    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Hp<=0)
        {
            
            Debug.Log("Glass crushed");
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(BreakingGlass,Vector3.zero);
            pars.Play();
        }
    }
}
