using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header(" Panels ")]
    [SerializeField] private GameObject connectionPannel;
    [SerializeField] private GameObject waitingPannel;
    [SerializeField] private GameObject gamePannel;
    void Start()
    {
        ShowConnectionPannel();
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;

        if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
        {
            ShowGamePannel();
        }
    }
    void Update()
    {
    }
    private void ShowConnectionPannel()
    {
        connectionPannel.SetActive(true);
        waitingPannel.SetActive(false);
        gamePannel.SetActive(false);
    }
    private void ShowWaitingPannel()
    {
        connectionPannel.SetActive(false);
        waitingPannel.SetActive(true);
        gamePannel.SetActive(false);
    }
    private void ShowGamePannel()
    {
        connectionPannel.SetActive(false);
        waitingPannel.SetActive(false);
        gamePannel.SetActive(true);
    }
    public void HostButtonCallback()
    {
        NetworkManager.Singleton.StartHost();
        ShowWaitingPannel();
    }
    public void ClientButtonCallback()
    {
        NetworkManager.Singleton.StartClient();
        ShowWaitingPannel();
    }

    private void OnClientConnected(ulong clientId)
    {
        // Esto se ejecuta en todos, pero filtramos para que solo actúe el HOST
        if (NetworkManager.Singleton.IsHost && clientId != NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Un nuevo cliente se conectó. Su ID es: " + clientId);

            // Acción que querés ejecutar solo en el host cuando alguien se conecta
            // Por ejemplo:
            ShowGamePannel();
        }
    }
}


