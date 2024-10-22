using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public bool hasJournal = false;

    //private float Move;
    //private float TopDown;

    public float speed;

    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite downSprite;

    public AudioSource soundEffects;
    public AudioClip[] sounds;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        //instance = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            sr.sprite = upSprite;
        }

        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            sr.sprite = leftSprite;
        }

        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            sr.sprite = downSprite;
        }

        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            sr.sprite = rightSprite;
        }

        transform.position = newPosition;

        //Move = Input.GetAxisRaw("Horizontal");
        //TopDown = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector2(TopDown * speed, rb.velocity.y);
        //rb.velocity = new Vector2(Move * speed, rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("door0"))
        {
            Debug.Log("change scene");
            //soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag.Equals("journal"))
        {
            Debug.Log("obtained journal");
            //soundEffects.PlayOneShot(sounds[0], .7f);
            hasJournal = true;
        }

        if (collision.gameObject.tag.Equals("door1") && hasJournal == true)
        {
            Debug.Log("Nice Journal Stinky!");
            //soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(2);
        }

        //if (collision.gameObject.tag.Equals("door1"))
        //{
           // Debug.Log("if you have no book then u can't come through");
        //}

        if(collision.gameObject.tag.Equals("Trader"))
            {
            Debug.Log("Hello young traveler. Can you help me find my map to the city?");

            }

        if(collision.gameObject.tag.Equals("Bad Warp"))
        {
            SceneManager.LoadScene(3);

        }

        if(collision.gameObject.tag.Equals("Good Warp"))
        {
            SceneManager.LoadScene(4);

        }
    }
}
