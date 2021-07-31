using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultUnlockDrill : MonoBehaviour
{
    public float startAngle = -1.41f;
    public float endAngle = 160f;
    public float openSpeed;
    public Transform hinge;
    [SerializeField] GameObject Door;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.tag == "Drill")
        {
            Debug.Log("Open VAULT");
            Debug.Log(other.gameObject.name);
            
            StartCoroutine(ToggleChest(startAngle, endAngle));

        }
    }

    IEnumerator ToggleChest(float angleStart, float angleEnd)
    {
        //audio.Play();

        angleStart = Door.transform.eulerAngles.y;

        float time = 0f;
        while (time <= 1f)
        {
            // Calculate currrent angle
            float angle = Mathf.Lerp(angleStart, angleEnd, time);

            //Get a copy of current Euler angles
            Vector3 euler = Door.transform.eulerAngles;

            // Set current angle
            euler.y = angle;

            // Reapply Euler angles to transform
            Door.transform.eulerAngles = euler;

            // Increment time
            time = time + Time.deltaTime / openSpeed;

            yield return null;

        }


    }
}
