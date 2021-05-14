using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastingSystem : MonoBehaviour
{
    public float touchRange; //The range of the raycast of objects we have to TOUCH with our HANDS. Ex: scrolls.
    bool isHovering;
    public Color defaultColor;
    public Color[] hoveringColors;
    public Color actualColor;

    enum ETypeOfHoveredObject { Interactable, Talkable, Enemy }
    ETypeOfHoveredObject currentlyHovered;
    List<LayerMask> masks = new List<LayerMask>();
    private void Start()
    {
        foreach (int i in Enum.GetValues(typeof(ETypeOfHoveredObject)))
        {
            masks.Add(LayerMask.GetMask(((ETypeOfHoveredObject)i).ToString()));
        }
        actualColor = defaultColor;
    }
    private void Update()
    {
        isHovering = false;
        actualColor = defaultColor;
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        

        // actual Ray
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * touchRange, Color.red);
        if (Physics.Raycast(ray, out hit, touchRange,masks[(int)ETypeOfHoveredObject.Interactable]))
        {
            isHovering = true;
            currentlyHovered = ETypeOfHoveredObject.Interactable;
            if (Input.GetButtonDown("Interact"))
            {
                hit.collider.GetComponent<IInteractable>().Interact();
            }
        }
        actualColor = hoveringColors[(int)currentlyHovered];
    }

}
