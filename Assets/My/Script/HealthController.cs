using System.Collections;
using System.Collections.Generic;
using UnityEngine; //Padrão da Unity
using UnityEngine.UI; //Para trabalhar com User Interface (Image)
using UnityEngine.SceneManagement; //Manipular cenas

public class HealthController : MonoBehaviour
{
    //Variaveis:
    public float health = 8; //Valor atual da vida
    public float healthMax = 10; //Valor maximo da vida
    public Image healthBar; //Imagem a representar barra de vida
    public ParticleSystem damager;
    public ParticleSystem healthMore;
    public AudioSource danoSource;
    public Transform lost;
    
    //Funções:
    private void Update() //Função para atualizar a barra
    {
        UpdateHealthBar();

        //Verificar vlor da vida igual ou menor que zero para reiniciar a cena
         if (health <= 0)
         {
             if(lost.gameObject.activeSelf)
             {
                 
             }
             else
             {
                lost.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
             }
             //SceneManager.LoadScene(1); //Reinicia a cena
         }

    }

    private void UpdateHealthBar() //Função calculo vida
    {
        //imagem.componente = vida atual / valor maximo
        healthBar.fillAmount = health / healthMax;
    }

     public void OnTriggerEnter(Collider other) //Função para verificar colisão
     {
         if (other.gameObject.CompareTag("Ocean")) //Verifica colisão com tag "Ocean"
         {
             health = 0; //Alterar valor da vida para
             //SceneManager.LoadScene(1); //Reinicia a cena
         }
         if (other.gameObject.CompareTag("Shootable")) //Verifica colisão com tag "Ocean"
         {
             health -= 4; //Alterar valor da vida para
             damager.Play();
             danoSource.Play();
             //SceneManager.LoadScene(1); //Reinicia a cena
         }

         //Cura:
         if (other.gameObject.CompareTag("cura"))
         {
             Destroy(other.gameObject);
             health = healthMax;
             healthMore.Play();
         }
     }

     public void OnParticleCollision(GameObject other) //Detecta colisão com particulas (neste caso é para o lança chamas)
     {
        if(other.gameObject.layer==9) //compara a camada (layer) de colisão de particulas
        {
            health -= 1; //Reduzir vida a cada colisão
            damager.Play();
            danoSource.Play();
           
           /*
            if (health <= 0) //Se vida for = ou menor que 0
            {
                SceneManager.LoadScene(1); //Reiniciar cena
            }
            */
        }    
     }

}
