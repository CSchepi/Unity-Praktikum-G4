using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVaultDoors : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Lever;

    Vector3 door1_start_pos;
    public Vector3 door1_end_pos;

    Vector3 door2_start_pos;
    public Vector3 door2_end_pos;
    public Vector3 lever_start_pos;

    private float lever_start_angle;
    private float lever_end_angle;

    public Vector3 lever_end_pos;

    float threshold = 0.0f;

    public float openSpeed = 1f;

    private bool started = true;


    public void Start()
    {
        door1_start_pos = Door1.transform.position;
        door2_start_pos = Door2.transform.position;
        lever_start_angle = Lever.transform.rotation.z;
        lever_end_angle = lever_start_angle;
    }

    public void Update()
    {
        if (started)
        {
            float offset = lever_start_angle - lever_end_angle;

            if (offset > threshold)
            {

                StartCoroutine(OpenDoor(door1_start_pos.x, door1_end_pos.x, door2_start_pos.x, door2_end_pos.x));
                started = false;

            }
            if (offset < threshold)
            {
                Debug.Log("went to offset <");

                OpenDoor(door1_start_pos.x, door1_end_pos.x, door2_start_pos.x, door2_end_pos.x);
            }

            lever_end_angle = Lever.transform.rotation.z;
        }

    }


    IEnumerator OpenDoor(float position1_z_start, float position1_z_end, float position2_z_start, float position2_z_end)
    {
        Debug.Log("openDoor");

        float time = 0f;
        while (time <= 1f)
        {
            Debug.Log(time);
            // Calculate currrent angle
            float angle1 = Mathf.Lerp(position1_z_start, position1_z_end, time);
            float angle2 = Mathf.Lerp(position2_z_start, position2_z_end, time);

            //Get a copy of current Euler angles
            Vector3 position1 = Door1.transform.position;
            Vector3 position2 = Door2.transform.position;


            // Set current angle
            position1.x = angle1;
            position2.x = angle2;


            // Reapply Euler angles to transform
            Door1.transform.position = position1;
            Door2.transform.position = position2;


            // Increment time
            time = time + Time.deltaTime / openSpeed;
            Debug.Log("and");
            Debug.Log(time);

            yield return null;

        }

    }

}
