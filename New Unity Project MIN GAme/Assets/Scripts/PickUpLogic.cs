using UnityEngine;
using System.Collections;

public class PickUpLogic : MonoBehaviour {

    public float TimeToDisappear = 10;

    private void OnEnable()
    {
        Invoke("Disapear", TimeToDisappear);
    }

    void Disapear()
    {
        ObjectPooling.instance.DestroyAPS(gameObject);
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }
}
