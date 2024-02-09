using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONnOffButton : MonoBehaviour
{
    public GameObject Shop;

    public void Trigger(){
        if(Shop.activeInHierarchy == false){
            Shop.SetActive(true);

        }
        else{
            Shop.SetActive(false);
        }
    }
}

