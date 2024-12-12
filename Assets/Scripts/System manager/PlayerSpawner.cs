using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform PlayerSpawnPos;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
    }

    public void PlayerSpawn()
    {
        Instantiate(Player, PlayerSpawnPos.position, Quaternion.identity);
    }
}
