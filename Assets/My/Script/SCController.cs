using UnityEngine;
using UnityEngine.SceneManagement;

public class SCController : MonoBehaviour
{
    
    public Light spotLight;
    public Color normalColor = Color.white;
    public Color suspiciousColor = Color.yellow;
    public Color alltertColor = Color.red;
    public float suspiciousTime = 4;
    public float allertTime = 3;
    private Transform cameraLens;
    private float timer;
    private Transform target;
    private Animator anim;
    public Transform lost;
    public bool update = false;

    private enum CameraState
    {
        Normal,
        Suspicious,
        Allert
    }
    private CameraState state;


    void Start()
    {
        lost = GameObject.Find("Lost").GetComponent<Transform>();

        /////
        state = CameraState.Normal;
        timer = 0;
        target = null;
        spotLight.color = normalColor;
        anim = GetComponent<Animator>();
        cameraLens = GetComponent<Transform>();
    }

    void Update()
    {
        //Pegar menu de derrota:
        if(update == false)
        {
            lost.gameObject.SetActive(false);
            update = true;
        }

        
        

        if (state == CameraState.Normal) return;

        if (target != null)
            cameraLens.LookAt(target.position);
        
        timer += Time.deltaTime;

        if (state == CameraState.Suspicious)
        {
            if (timer >= suspiciousTime)
            {
                if (target != null)
                {
                    timer = 0;
                    spotLight.color = alltertColor;
                    state = CameraState.Allert;
                } 
                else
                {
                    spotLight.color = normalColor;
                    state = CameraState.Normal;
                    anim.enabled = true;
                }
            }
            
        }
        else if (state == CameraState.Allert)
        {
            if (timer >= allertTime)
            {
                if (target != null)
                {
                    lost.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                } 
                else
                {
                    spotLight.color = normalColor;
                    state = CameraState.Normal;
                    anim.enabled = true;
                }
            }
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            state = CameraState.Suspicious;
            spotLight.color = suspiciousColor;
            target = other.transform;
            anim.enabled = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }





}
