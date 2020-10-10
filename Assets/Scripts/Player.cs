using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _tripleshotPrefab;

    public bool _canTripleShoot = false;

    [SerializeField]
    private GameObject _superGameObject;

    [SerializeField]
    private GameObject _shieldGameObject;

    public bool shieldsActive = false;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    public int lives = 3;
    private UIManager _uiManager;

    public bool _canSuper = false;

    private float _fireRateSuper = 15.0F;
    private float _canFireSuper = 0.0f;

    private AudioSource _audioSource;

    [SerializeField]
    private GameObject[] _engines;

    private int hitCount = 0;
        
    void Start()
    {
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SuperShot();
        }

    }

    private void SuperShot()
    {
        if (Time.time > _canFireSuper)
        {
            _canSuper = true;
            if (_canSuper == true) 
            {
                _superGameObject.SetActive(true);
                StartCoroutine(SuperRoutine());
            }
            _canFireSuper = Time.time + _fireRateSuper;
        }
    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();
            if (_canTripleShoot == true)
        {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector2.up * _speed * verticalInput * Time.deltaTime);

        if (transform.position.y > -2f)
        {
            transform.position = new Vector2(transform.position.x, -2f);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector2(transform.position.x, -4.2f);
        }

        if (transform.position.x > 4.1f)
        {
            transform.position = new Vector2(-4.1f, transform.position.y);
        }
        else if (transform.position.x < -4.1f)
        {
            transform.position = new Vector2(4.1f, transform.position.y);
        }
    }

    public void Damage()
    {

        if (shieldsActive == true)
        {
            shieldsActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }

        hitCount++;
        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            _engines[1].SetActive(true);
        }

        lives--;
        _uiManager.UpdateLives(lives);

        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void EnableShields()
    {
        shieldsActive = true;
        _shieldGameObject.SetActive(true);
    }

    public void TripleShotPowerupOn()
    {
        _canTripleShoot = true;
        StartCoroutine(TripleShotPowerupRoutine());
    }

    public IEnumerator TripleShotPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _canTripleShoot = false;
    }

    public IEnumerator SuperRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _superGameObject.SetActive(false);
        SceneManager.GetActiveScene();
    }

   
}
