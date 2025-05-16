using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAppearance : NetworkBehaviour
{
    public Sprite hostSprite;
    public Sprite clientSprite;

    private SpriteRenderer spriteRenderer;

    // Cada jugador decide cuál sprite usar y lo sincroniza
    private NetworkVariable<bool> useHostSprite = new NetworkVariable<bool>(
        false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            // Cada jugador define si debe usar el sprite de host o no
            useHostSprite.Value = IsHost;
        }

        // Al conectarse o al cambiar el valor, actualizamos el sprite
        useHostSprite.OnValueChanged += (_, newValue) =>
        {
            UpdateSprite(newValue);
        };

        // También aplicamos inmediatamente por si ya está asignado
        UpdateSprite(useHostSprite.Value);
    }

    void UpdateSprite(bool isHost)
    {
        spriteRenderer.sprite = isHost ? hostSprite : clientSprite;
    }
}
