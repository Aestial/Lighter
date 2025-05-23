using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreakTiles : MonoBehaviour, IBreakable
{ 
    public void Break()
    {

        void OnCollisionExit(Collision other)
        {
                //this.gameObject.SetActive(false);
                //loadWave.sound();
                //loadWave.UpdateEliminados(eliminado);
                //loadWave.UpdateSpeed(vel);
                Destroy(gameObject);
        }
    }
}
