using UnityEngine;
using Unity.Netcode;

public class ClientManager : MonoBehaviour
{
    private ServerData data;
    
    void Start()
    {
        data = GetComponent<ServerData>();  
        NetworkManager.Singleton.OnConnectionEvent += OnClientConnected;
    }

    void OnClientConnected(NetworkManager manager, ConnectionEventData cData)
    {
        // When a client connects add the client's fleet to the fleet list
        data.AddFleet(NetworkManager.Singleton.ConnectedClients[cData.ClientId].PlayerObject.gameObject);
    }
}
