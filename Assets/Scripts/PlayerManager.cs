using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerManager", menuName = "ScriptableObjects/PlayerManager", order = 1)]
public class PlayerManager : ScriptableObject
{
    List<GameObject> players = new List<GameObject>();
}
