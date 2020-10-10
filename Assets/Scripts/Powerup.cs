using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.EnableShields();
                }
                else if(powerupID == 1)
                        {
                    player.TripleShotPowerupOn();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
