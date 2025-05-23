using UnityEngine;

public class Contador : MonoBehaviour, ICollectable<int>
{
    [SerializeField] int contador = 0;
    [SerializeField] int total = 0;

    public void PointCount(int point)
    {
        total += point;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Item")
        {
            int puntos = 0;
            //int puntos = col.transform.parent.GetComponent("CollectableObject").getPoints();        
            PointCount(puntos);
            Debug.Log("Puntos: "+ total);
        }
    }

    void Start()
    {  
        contador = total;
    }


}
