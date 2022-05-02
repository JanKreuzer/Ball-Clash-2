using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public KeyCode keycode;
    public KeyCode keycodereset;
    int newforce = 2;
    public GameObject wurfding;
    public Image lebensleiste;
    public GameObject ui;
    public GameManager manager;
    public int dir;
    public float leben = 10;
    public Text lebentext;
    public Text wurftext;
    public AudioClip clip;
    float force;


    // Start is called before the first frame update
    void Start()
        {
            lebentext.text = leben.ToString();
            wurftext.text = force.ToString();
        }

    // Update is called once per frame
    void Update()
        { 
            if(manager.gamekeys==false) return;
            if (Input.GetKey(keycode))
                {
                    force = force+newforce;
                    wurftext.text = force.ToString();
                }

            if (Input.GetKeyUp(keycode))
                {
                    GameObject ding = Instantiate(wurfding, transform.position+(new Vector3(4*dir,0,0)), Quaternion.identity);
                    ding.GetComponent<Rigidbody>().AddForce(new Vector3(force*dir*8,force*8,0));
                    force=0;
                    Destroy(ding,6);
                }

            if(leben<1)
                {
                    gameObject.SetActive(false);
                    ui.SetActive(false);

                }
        }
   
    void OnCollisionEnter(Collision collision)
        {
            lebensleiste.fillAmount= lebensleiste.fillAmount-0.1F;
            Destroy(collision.gameObject);
            leben=leben-1;
            lebentext.text = leben.ToString();
            AudioSource.PlayClipAtPoint(clip,transform.position);
        }
} 
