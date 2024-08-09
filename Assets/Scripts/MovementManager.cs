using Unity.Netcode;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private ServerData data;

    void Awake()
    {
        data = GetComponent<ServerData>(); 
        // Invoke the move update, repeating every tick to move all ships each tick
        InvokeRepeating("MoveUpdate", 1.0f, 1.0f);
    }

    // We move everythin in one update function to ensure all objects move in sync on a synced tick
    void MoveUpdate()
    {
        int count = data.GetFleetListSize();

        // For each fleet the server is managing
        for(int i = 0; i < count; i++)
        {
            // Get the fleet object along with it's network object and the name of it's destination
            GameObject fleet = data.GetFleetIndex(i);
            FleetNetwork fleetData = fleet.GetComponent<FleetNetwork>();
            string destinationName = fleetData.ServerGetDestination();

            // If the fleet doesn't have a destination we can go to the next fleet
            if (destinationName == "")
                continue;

            // Get the object that represents it's destination
            GameObject destination = GameObject.Find(destinationName);

            // If that didn't find an object then the destination is invalid
            if(destination == null) 
            {
                Debug.LogError("Invalid destination on Fleet " + fleet.name + " owned by " + fleetData.OwnerClientId + " destination was not an object");
                continue;
            }

            // If the destination wasn't a star then it's invalid as fleets can only go to locations, not any object
            if (destination.GetComponent<Star>() == null)
            {
                Debug.LogError("Invalid destination on Fleet " + fleet.name + " owned by " + fleetData.OwnerClientId + " destination was not a location");
                continue;
            }

            // Get the distance between the current position and the destination
            Vector3 moveDistance = destination.transform.position - fleet.transform.position;

            // For now we move by 1 unit at a time, so if the magnitude is less then 1 we can arrive at the destination
            if (moveDistance.magnitude <= 1.0f)
            {
                fleet.transform.position = destination.transform.position;
                fleetData.SetDestinationRpc("");
            }
            // If the magnitude is greater then one then add the normalized distance (magnitude of 1) to the position to move 1 unit towards the destination
            else
                fleet.transform.position += moveDistance.normalized;
        }
    }
}
