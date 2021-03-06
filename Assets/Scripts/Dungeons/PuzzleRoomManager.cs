using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PuzzleRoomManager : MonoBehaviour
{
    public static PuzzleRoomManager Instance;
    public List<int> solution = new List<int>();
    public int state;
    public Transform[] rooms;
    public Transform runePos;
    public GameObject[] runes;
    public Transform winRoom;
    [Range(0,60), Tooltip("Corresponds to the number of runes\nto remember, *3. Default : 30. (So, 10 runes to remember.)")] public int difficulty = 30;

    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        for (int i = 3; i <= difficulty; i += 3)
        {
            solution.Add(Random.Range(i - 2, i));
        }
        foreach ((int item, int index) in solution.Select((item,index)=>(item,index)))
        {
            GameObject rune = Instantiate(runes[item], runePos);
            MeshFilter filter = rune.GetComponent<MeshFilter>();
            rune.transform.localPosition = new Vector3(0, 0, index + 1.5f);
            rune.transform.localRotation = Quaternion.Euler(new Vector3(0,90,90));
        }
    }
    public void NextStep(int TPEntered)
    {
        if (state + 1 < solution.Count) {
            if (TPEntered == solution[state])
                state++;
            else
                state = 0;
            PlayerController.Instance.PlayerMovement.Teleport(rooms[state].position);
            PlayerController.Instance.PlayerMovement.transform.rotation = rooms[state].rotation;
        } else {
            PlayerController.Instance.PlayerMovement.Teleport(winRoom.position);
            PlayerController.Instance.PlayerMovement.transform.rotation = winRoom.rotation;
        }

        if (((VoidElement)PlayerController.Instance.PlayerStats.ActualElement).ActualTPPoint != null)
        {
            Destroy(((VoidElement)PlayerController.Instance.PlayerStats.ActualElement).ActualTPPoint);
        }
    }
}
