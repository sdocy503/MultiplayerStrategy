using UnityEngine;
using Unity.Netcode;
using Unity.Multiplayer;
using Unity.Multiplayer.Editor;

public class NetworkConnectServer : MonoBehaviour
{
    [SerializeField]
    private NetworkManager manager;

    void Start()
    {      
        manager.StartServer();
    }
}
