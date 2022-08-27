using UnityEngine;


public class TurretController : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform muzzle;
    public float shotFrequency = 5F;
    public float initialBulletForce = 1000;
    public Transform cannonPivot;
    public float timer;
    private Transform target;
    public AudioSource audioSourceShoting;



    public void Start()
    {
        timer = 0;
        target = null;
    }

    public void Update()
    {
        /*if (target == null)
        {
            return;
        }*/

        cannonPivot.LookAt(target);

        // Segunda linha de c�digo mais importante deste semestre:
        //   como contar o tempo em segundos no Unity
        timer += Time.deltaTime; //contagem de tempo por segundo
        if (timer >= shotFrequency) //Se tempo for maior ou igual shotFrequency, quero que atire e o tempo zere
        {
            Rigidbody bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            bullet.AddForce(muzzle.forward * initialBulletForce);
            Destroy(bullet.gameObject, 2);
            audioSourceShoting.Play();
            timer = 0;
        }
    }

    // Existem duas categorias de fun�o de colis�o no Unity
    // 1-) OnCollision..., que � utilizado para detectar colis�o com GameObjects que
    //     n�o possuem a propriedade "IsTrigger" setada
    // 2-) OnTrigger... mesma finalidade do OnCollision, mas para quando o "IsTrigger" est�
    //     setado.

    // Os tr�s pontos nas duas categorias de fun��es de colis�o representam o instante em
    // que a colis�o � detectada, e existem tr�s possibilidades:
    // 1-) Enter: significa que o teste de colis�o � feito no primeiro momento (frame) em que
    //     a colis�o � detectada.
    // 2-) Exit: significa que o teste de colis�o � feito no primeiro momento (frame) em que
    //     a colis�o deixa de ser detectada.
    // 3-) Stay: o teste de colis�o � feito durante todos os frames em que a colis�o ocorre. 


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.transform; //Olhar para objeto com tag "Player"
        }
    }

    //Resetar posição da mira quando "Player" sair da soda de colisão (OnTriggerExit)
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
            cannonPivot.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
