using UnityEngine;

public class FlameThrowerController : MonoBehaviour
{
    public Transform cannonPivot;
    public ParticleSystem flames;
    private Transform target;
    public float timer;
    public float flameInit;
    public float flameStop;
    private int cont;
    public AudioSource flameShoting;

    public void Start()
    {
        target = null;
        flames.Stop();
        timer = 0;
        cont = 0;
    }

    public void Update()
    {
        /*if (target == null)
        {
            return;
        }*/

        timer += Time.deltaTime; //Contagem de tempo por segundo
        
        if (timer >= flameInit && cont == 0)
        {
            flames.Play();
            flameShoting.Play();
            cont = 1;
        }
        else if (timer >= flameStop && cont == 1)
        {
            flames.Stop();
            timer = 0;
            cont = 0;
        }

        cannonPivot.LookAt(target);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.transform;
            //flames.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
            cannonPivot.localEulerAngles = new Vector3(0, 0, 0);
            //flames.Stop();
        }
    }
}
