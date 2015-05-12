using System.Collections;
using UnityEngine;

public class MuseumDoor : MonoBehaviour
{
    public enum MuseumDoors { DoorLeft, DoorRight };

    public MuseumDoor Instance;
    public MuseumDoors WhichMuseumDoor;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (GateWheel.AmountOfBlueButtons < 6)
            return;

        if (WhichMuseumDoor == MuseumDoors.DoorLeft)
        {
            var target = new Vector3(-56.486f, 33.08f, 90.953f);
            Instance.transform.position = Vector3.MoveTowards(Instance.transform.position, target, 1 * Time.deltaTime);
        }
        else if (WhichMuseumDoor == MuseumDoors.DoorRight)
        {
            var target = new Vector3(-49.937f, 33.08f, 95.85f);
            Instance.transform.position = Vector3.MoveTowards(Instance.transform.position, target, 1 * Time.deltaTime);
        }
    }
}

