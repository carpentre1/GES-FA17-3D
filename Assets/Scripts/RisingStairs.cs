using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingStairs : MonoBehaviour, IActivatable
{

    public GameObject theStairs;
    public AudioClip rumble;
    public AudioSource source;
    bool activated;

    [SerializeField]
    private string nameText = "Stair Raiser";

    public string NameText
    {
        get
        {
            return nameText;
        }
    }

    public void DoActivate()
    {
        if (activated) return;
        if(theStairs.name == "FinalStairs")//if these are the second set of stairs that lead to the top of the mountain
        {
            theStairs.transform.position = new Vector3(theStairs.transform.position.x, theStairs.transform.position.y + 12.8f, theStairs.transform.position.z);//shift them up into the air by 6
            Debug.Log("y");
        }
        else
        {
            theStairs.transform.position = new Vector3(theStairs.transform.position.x, theStairs.transform.position.y + 3, theStairs.transform.position.z);
        }
        Debug.Log(this.gameObject.name + " was activated.");
        source.PlayOneShot(rumble);//play the rumbling noise to let the player know something happened
        activated = true;//can't activate it more than once
    }
}