using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Netcode;
public class PlayerDialogue : NetworkBehaviour
{

    [SerializeField]
    private GameObject comicBubble;
    [SerializeField]
    private TextMeshPro conkerText;

    public string[] textLines;
    private int lineIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (IsOwner)
        {
            StartCoroutine(InvokeDialogue());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InvokeDialogue()
    {
        while (true)
        {
            conkerText.text = textLines[Random.Range(0, 10)];
            float tiempoEspera = Random.Range(10f, 30f); // Tiempo aleatorio en segundos
            yield return new WaitForSeconds(tiempoEspera);

            // Acá va lo que querés que pase
            Debug.Log("Se ha activado el Dialogue");

            // Por ejemplo, podrías activar algo:
            comicBubble.SetActive(true);

            // Esperar 5 segundos con el bubble activo
            yield return new WaitForSeconds(5f);

            comicBubble.SetActive(false);
        }
    }
}
