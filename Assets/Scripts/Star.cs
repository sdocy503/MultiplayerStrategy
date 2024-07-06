using UnityEngine;
using Unity.Netcode;

public class Star : MonoBehaviour
{
    private NetworkManager NetworkManager;
    private FleetNetwork CurrentPlayer;

    void OnMouseDown()
    {
        if(NetworkManager == null)
        {
            NetworkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
            CurrentPlayer = NetworkManager.LocalClient.PlayerObject.GetComponent<FleetNetwork>();
        }

        CurrentPlayer.SetDestinationRpc(gameObject.name);
    }
}
