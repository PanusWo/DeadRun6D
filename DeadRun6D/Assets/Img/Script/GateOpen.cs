using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public Animation Cdoor;
    public Component doorCor;
    public Component BarCor;
    public GameObject PText;
    public AudioSource OpenS;




    // Start is called before the first frame update
    void Start()
    {
        doorCor.GetComponent<BoxCollider>().enabled = false;
        BarCor.GetComponent<CapsuleCollider>().enabled = true;
        PText.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PText.SetActive(true);
            if (Input.GetKey(KeyCode.F)) 
            { 
                this.GetComponent<CapsuleCollider>().enabled = false;
                Cdoor.Play();
                PText.SetActive(false);
                OpenS.Play();
                this.GetComponent<BoxCollider>().enabled = false;
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        PText.SetActive(false);
    }
}
