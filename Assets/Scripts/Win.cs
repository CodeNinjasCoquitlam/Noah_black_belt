using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public PlayerControls playerControls;
    public GameObject player;

    public Rigidbody rigidbody;

    void Start()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 6")
        {
            playerControls.gravity = -300f;
            player.GetComponent<Rigidbody>().drag = 2;
        }

        if (scene.name == "Level 7")
        {
            playerControls.gravity = -2500f;
            player.GetComponent<Rigidbody>().drag = 5;
        }

        if (scene.name == "Level 8")
        {
            playerControls.gravity = -700f;
            player.GetComponent<Rigidbody>().drag = 5;
        }
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            /*if (scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }

            if (scene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }

            if (scene.name == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }

            if (scene.name == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }*/

        }
    }
}
