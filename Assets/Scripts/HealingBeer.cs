using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBeer : MonoBehaviour
{
    public GameObject fullMug;
    public GameObject emptyMug;
    
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && fullMug.activeSelf)
        {
            PlayerUIManager.Instance.beerDisplayed = true;
            if (Input.GetButtonDown("Interact"))
            {
                fullMug.SetActive(false);
                emptyMug.SetActive(true);
                PlayerStats.Instance.HP = 100;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerUIManager.Instance.beerDisplayed = false;
        }
    }

}