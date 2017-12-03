using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float timeLeft = 0;

    public RaycastHit hit;
    public Transform currentDoor;
    public Transform cam;

    public bool open;
    public bool isOpeningDoor;

    public LayerMask mask;

    public void CheckDoor()
    {
        if(Physics.Raycast(cam.position, cam.forward, out hit, 5, mask))
        {
            open = false;
            if(hit.transform.localRotation.eulerAngles.y > 45)
            {
                open = true;
            }
            isOpeningDoor = true;
            currentDoor = hit.transform;
        }
    }
    public void ToggleDoor()
    {
        timeLeft += Time.deltaTime;
        if (open)
        {
            currentDoor.localRotation = Quaternion.Slerp(currentDoor.localRotation, Quaternion.Euler(0, 0, 0), timeLeft);
        }
        else
        {
            currentDoor.localRotation = Quaternion.Slerp(currentDoor.localRotation, Quaternion.Euler(0, -90, 0), timeLeft);
        }
        if(timeLeft > 1)
        {
            timeLeft = 0;
            isOpeningDoor = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && timeLeft == 0f)
        {
            CheckDoor();
        }
        if(isOpeningDoor)
        {
            ToggleDoor();
        }
    }
}
