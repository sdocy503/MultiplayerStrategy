using UnityEngine;
using Unity.Netcode;
using TMPro;

public class Star : MonoBehaviour
{
    private NetworkManager NetworkManager;
    private FleetNetwork CurrentPlayer;

    private void Start()
    {
        // Get the label for the location
        TMP_Text text = GetComponentInChildren<TMP_Text>();

        // If the label is valid, this is not valid on the server as UI is stripped
        if (text)
        {
            // Set the label to the name of the game object
            text.text = gameObject.name;
        }
    }

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
