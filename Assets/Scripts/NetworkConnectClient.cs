using UnityEngine;
using Unity.Netcode;
using Unity.Multiplayer;
using Unity.Multiplayer.Editor;

public class NetworkConnectClient : MonoBehaviour
{
    [SerializeField]
    private NetworkManager manager;

    void Start()
    {     
        manager.StartClient();
    }
}
