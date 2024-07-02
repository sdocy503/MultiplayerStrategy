using UnityEngine;
using Unity.Netcode;
using Unity.Multiplayer;
using Unity.Multiplayer.Editor;

public class NetworkConnect : MonoBehaviour
{
    private NetworkManager manager;

    void Start()
    {
        manager = GetComponent<NetworkManager>();

        if(EditorMultiplayerRolesManager.ActiveMultiplayerRoleMask == MultiplayerRoleFlags.Server)
        {
            manager.StartServer();
            return;
        }

        manager.StartClient();
    }
}
