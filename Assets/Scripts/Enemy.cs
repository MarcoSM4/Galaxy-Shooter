using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private AudioClip _clip;
    private UIManager _uiManager;

    void Start()
    {
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            float randomX = Random.Range(-2.9f, 2.9f);
            transform.position = new Vector2(randomX, 6.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Super")
        {
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
