using UnityEngine;

public class CollectableObject : MonoBehaviour, IBreakable, ICollectable<int>
{
 [SerializeField] int contador = 0;
 public int puntos;
 public int point;

    public void Break()
    {
        Destroy(this.gameObject);
    }

//Quizá hay que mover este al contador
    public void PointCount(int point)
    {
        contador = puntos + point;
        Break();
    }

    public int getPoints()
    {
        return puntos;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            PointCount(1);
            Debug.Log("Points: "+ contador);
            getPoints();
        }
    }

    void Start()
    {
        puntos = contador;
    }

}
