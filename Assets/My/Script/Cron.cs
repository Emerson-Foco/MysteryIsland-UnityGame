using UnityEngine;
using TMPro; //Editar texto UI para cronometro
using UnityEngine.SceneManagement; //Gerenciar as cenas da Unity

public class Cron : MonoBehaviour
{
    // Variáveis:
    public TextMeshProUGUI timerUI;
    public float totalTime = 301; // Tempo em segundos
    private float timer;
    public Transform lost;


    // Start is called before the first frame update
    void Start()
    {
        timer = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int minutes = (int)(timer / 60); //pegar valor da divisão (minutos)
        int seconds = (int)(timer % 60); //pegar resto da divisão (segundos)
        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (timer <= 0)
        {
            lost.gameObject.SetActive(true);
            //SceneManager.LoadScene(0);
        }
    }


}
