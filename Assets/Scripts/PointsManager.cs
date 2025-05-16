using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static int GamePoints;
    public TextMeshProUGUI puntosTexto;

    // Start is called before the first frame update
    void Start()
    {
        GamePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        puntosTexto.text = GamePoints.ToString();

        if (GamePoints >= 100)
        {
            SceneManager.LoadScene("YouWinScreen");
        }
    }
}
