using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerManager", menuName = "ScriptableObjects/PlayerManager", order = 1)]
public class PlayerManager : ScriptableObject
{
    [SerializeField]
    List<GameObject> players = new List<GameObject>();

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public GameObject FindCurrentPlayer()
    {
        foreach(GameObject player in players) 
        {
            PlayerNetwork playerNetwork = player.GetComponent<PlayerNetwork>();
            if (playerNetwork == null)
                Debug.Log("Player Network is null");
            else if (playerNetwork.IsOwner)
                return player;
        }
        return null;
    }
}
