using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningSystem : MonoBehaviour
{
    public Animator DoorAnim;

    private void Start()
    {
        DoorAnim = this.transform.parent.GetComponent<Animator>();
        DoorAnim.SetBool("OpenDoor", true);
    }
}

