using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    public static List<GameObject> players = new List<GameObject>();

    public GameObject MainPlayer;
    public GameObject Character1;

    void Awake()
    {
        AddPlayer(MainPlayer);
        AddPlayer(Character1);
    }

    public static void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public static void RemovePlayer(GameObject player)
    {
        players.Remove(player);
    }

    public static int GetPlayerCount()
    {
        return players.Count;
    }
}
