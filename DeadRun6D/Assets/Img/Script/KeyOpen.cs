using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpen : MonoBehaviour
{
    public GameObject KeyOnPlayer;
    public GameObject PText;
    public Component doorCor;


    void Start()
    {
        KeyOnPlayer.SetActive(false);
        PText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PText.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                
                this.gameObject.SetActive(false);
                KeyOnPlayer.SetActive(true);
                doorCor.GetComponent<BoxCollider>().enabled = true;
                PText.SetActive(false);
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PText.SetActive(false);
    }
}
