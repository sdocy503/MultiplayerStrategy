using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [Rpc(SendTo.Server)]
    public void MovePlayerRpc(Vector3 position)
    {
        transform.position = position;
    }
}
