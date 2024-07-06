using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class ServerData : MonoBehaviour
{
    private List<GameObject> Fleets = new List<GameObject>();

    public void AddFleet(GameObject fleet)
    {
        Fleets.Add(fleet);
    }

    public GameObject GetFleetIndex(int index)
    {
        return Fleets[index];
    }

    public int GetFleetListSize()
    { 
        return Fleets.Count; 
    }
}
