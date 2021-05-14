using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneScroll : MonoBehaviour, IInteractable
{
    public GameObject[] elementsParticles;
    public EElements scrollElement;
    public enum EScrollTypes { Tutorial, Spell }
    public EScrollTypes scrollType;
    [Header("Tutorial: (empty if scrollType = Spell)")]
    public Element elementToAdd;
    private void OnEnable()
    {
        elementsParticles[(int)scrollElement].SetActive(true);
    }
    public void Interact()
    {
        if (scrollType == EScrollTypes.Tutorial)
        {
            TextingSystemManager.Instance.NextLine();
            Destroy(gameObject);
            if (!PlayerUIManager.Instance.hudActive) PlayerUIManager.Instance.ToggleHud(true);

            PlayerStats.Instance.elements.Add(elementToAdd);
            elementToAdd.Init();
            PlayerStats.Instance.ChangeElement(scrollElement);
            PlayerStats.Instance.canOpenDoors = true;
        }
    }

    public void Hovered(bool isHovered)
    {
        Debug.Log("Need to implement Hovering Scrolls -> need a crosshair");
    }
}
