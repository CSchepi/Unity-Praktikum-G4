using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLiftDoor : MonoBehaviour
{
    public void _openDoor()
    {
        StartCoroutine(ScaleDownAnimation(3.0f));

        //transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
        
    }
    
    IEnumerator ScaleDownAnimation(float time)
    {
        
        float i = 0;
        float rate = 1 / time;

        Vector3 fromScale = transform.localScale;
        Vector3 toScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
        
        while (i<1)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }
}
