using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header(" Panels ")]
    [SerializeField] private GameObject lorePannel;
    [SerializeField] private GameObject mainPannel;
    void Start()
    {
        ShowMainPanel();
    }
    void Update()
    {
    }
    public void ShowLorePanel()
    {
        lorePannel.SetActive(true);
        mainPannel.SetActive(false);
    }
    public void ShowMainPanel()
    {
        lorePannel.SetActive(false);
        mainPannel.SetActive(true);
    }
    public void PlayButtonCallback()
    {
        SceneManager.LoadScene("Bootstrap");
    }
}
