using Unity.Netcode;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private ServerData data;

    void Awake()
    {
        data = GetComponent<ServerData>(); 
        InvokeRepeating("MoveUpdate", 1.0f, 1.0f);
    }

    void MoveUpdate()
    {
        int count = data.GetFleetListSize();

        for(int i = 0; i < count; i++)
        {
            GameObject fleet = data.GetFleetIndex(i);
            FleetNetwork fleetData = fleet.GetComponent<FleetNetwork>();
            string destinationName = fleetData.ServerGetDestination();

            if (destinationName == "")
                continue;

            GameObject destination = GameObject.Find(destinationName);

            if(destination == null) 
            {
                Debug.LogError("Invalid destination on Fleet " + fleet.name + " owned by " + fleetData.OwnerClientId + " destination was not an object");
                continue;
            }

            if (destination.GetComponent<Star>() == null)
            {
                Debug.LogError("Invalid destination on Fleet " + fleet.name + " owned by " + fleetData.OwnerClientId + " destination was not a location");
                continue;
            }

            Vector3 moveDistance = destination.transform.position - fleet.transform.position;

            if (moveDistance.magnitude <= 1.0f)
            {
                fleet.transform.position = destination.transform.position;
                fleetData.SetDestinationRpc("");
            }
            else
                fleet.transform.position += moveDistance.normalized;
        }
    }
}
