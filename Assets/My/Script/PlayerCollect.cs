using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    //public float maxHP = 100;
    //public Image lifebar;
    //private float hp;
    public AudioSource collect;
    public Transform objective1;
    public Transform objective2;
    public Transform objective3;
    public Transform objective4;
    public int contObjectiveComplete = 0;

    public GameObject finalGame;
    public GameObject fakeBot;

    //Variáveis para Paper:
    private PaperNote note;

    //Variáveis para Final:
   private Animator cutScene;
    

    void Start()
    {
        finalGame.gameObject.SetActive(false);
        fakeBot.gameObject.SetActive(true);
    }

    public void Update()
    {

        //////cheat//////
        if(Input.GetKeyDown("i"))
        {
            finalGame.gameObject.SetActive(true);
            fakeBot.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if(contObjectiveComplete == 3)
        {
            objective4.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Objetivo 1 (Livro):
        if (other.gameObject.CompareTag("ObjectiveLivro"))
        {
            Destroy(other.gameObject);
            collect.Play();
            objective1.gameObject.SetActive(false);
            contObjectiveComplete ++;
        }
        
        //Objetivo 2 (chave):
        if (other.gameObject.CompareTag("Objective"))
        {
            Destroy(other.gameObject);
            collect.Play();
            objective2.gameObject.SetActive (false);
            contObjectiveComplete ++;
        }

        //Objetivo 3 (Combustivel):
        if (other.gameObject.CompareTag("ObjectiveFuel"))
        {
            Destroy(other.gameObject);
            collect.Play();
            objective3.gameObject.SetActive(false);
            contObjectiveComplete ++;
        }

        if (other.gameObject.CompareTag("cura"))
        {
            collect.Play();
        }

        //Coletando Papers:
        if (other.gameObject.CompareTag("Paper"))
        {
            note = other.gameObject.GetComponent<PaperNote>();
            note.paperNote.gameObject.SetActive(true);
            Destroy(other.gameObject);
            collect.Play();
        }
        
        //Concluir nível:
        if (other.gameObject.CompareTag("Concluir"))
        {
        //Liberar ultimo objetivo:
            if(objective4.gameObject.activeSelf)
            {
                if (contObjectiveComplete == 3)
                {
                    finalGame.gameObject.SetActive(true);
                    fakeBot.gameObject.SetActive(false);
                    Destroy(gameObject);
                    objective4.gameObject.SetActive(true);
                    fakeBot.gameObject.SetActive(false);
                }
            }
            else
            {

            } 
        }
        

        /*
        if (other.gameObject.CompareTag("HealthPack"))
        {
            Destroy(other.gameObject);
            hp = hp + 10;
            if (hp >= maxHP)
            {
                hp = maxHP;
            }

            lifebar.fillAmount = hp / maxHP;    
        }



        if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            hp = hp - 10;
            if (hp == 0)
            {
                SceneManager.LoadScene(0);
            }

            lifebar.fillAmount = hp / maxHP;    
        }
        */
    }

}
