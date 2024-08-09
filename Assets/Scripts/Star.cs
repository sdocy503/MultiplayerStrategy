using UnityEngine;
using Unity.Netcode;

public class Star : MonoBehaviour
{
    private NetworkManager NetworkManager;
    private FleetNetwork CurrentPlayer;

    void OnMouseDown()
    {
        // If we don't have the network manager reference yet get that reference
        // as well as a reference to the fleet network script for the current player
        if(NetworkManager == null)
        {
            NetworkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
            CurrentPlayer = NetworkManager.LocalClient.PlayerObject.GetComponent<FleetNetwork>();
        }

        // After clicking set the destination of the current player 
        CurrentPlayer.SetDestinationRpc(gameObject.name);
    }
}
