using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CustomPlayerSpawner : NetworkBehaviour
{
    public Transform hostSpawnPoint;
    public Transform clientSpawnPoint;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Transform spawnPoint = IsHost ? hostSpawnPoint : clientSpawnPoint;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }
    }
}
