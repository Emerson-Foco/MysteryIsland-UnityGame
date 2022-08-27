using UnityEngine;

public class UnityBasic : MonoBehaviour
{

    public float rotSpeed = 10.0F;
    public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Primeira coisa mais importante do semestre em programação:
        //Como acessar os componentes de um GameObject no código
        //variavel = pegar componente <componente>();
        myTransform = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Segunda coisa mais importante do semestre em programação:
        //Time.deltaTime faz com que a simulação seja executada por segundos e não por frame.
        //limitar alteração por segundo e não por frame (* Time.deltaTime)
        myTransform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }

}
