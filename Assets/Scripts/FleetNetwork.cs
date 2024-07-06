using Unity.Netcode;
using UnityEngine;

public class FleetNetwork : NetworkBehaviour
{
    // This is only set on the server, not on the client
    private string destination = "";

    [Rpc(SendTo.Server)]
    public void SetDestinationRpc(string position)
    {
        destination = position;
    }

    // Should only be called by the server, if the client calls it should be empty
    public string ServerGetDestination()
    {
        return destination;
    }
}