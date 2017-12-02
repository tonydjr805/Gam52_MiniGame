using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponHolder : MonoBehaviour {

    public List<Gun> guns;
    public int GunIndex;
    public bool gunEqquiped;
    public bool mechineGunEqquiped;
    public bool shotGunEqquiped;


    private void Start()
    {
        GunSelect();
    }

    private void Update()
    {
        var ms = Input.GetAxis("Mouse ScrollWheel");

        if (ms > 0f)
        {
            //ScrollUp
            GunIndex++;
            GunSelect();
        }
        if (ms < 0f)
        {
            //ScrollDown
            GunIndex--;
            GunSelect();
        }

        if (GunIndex < 0)
        {
            GunIndex = 2;
            GunSelect();
        }
            
    }


    public void GunSelect()
    {

        if (GunIndex > 2)
            GunIndex = 0;

        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == GunIndex)
                gun.gameObject.SetActive(true);
            else gun.gameObject.SetActive(false);

            i++;
        }

       

    }
}
