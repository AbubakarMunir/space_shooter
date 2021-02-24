using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBycontact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;
    public int scorevalue;
    private GameController gc;

    void Start()
    {
        GameObject gcobject= GameObject.FindWithTag("GameController");
        if(gcobject!=null)
        {
            gc = gcobject.GetComponent<GameController>();
        }
        if(gcobject==null)
        {
            Debug.Log("gco not found");
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag=="Player")
        {
            Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
        }
        gc.addscore(scorevalue);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
