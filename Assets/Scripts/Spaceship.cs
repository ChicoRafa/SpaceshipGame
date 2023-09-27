using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spaceship : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 5f;
    public Rigidbody2D rbSpaceship;
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;
    private GameManager gameManager;
    public Joystick joystick;
    public VirtualButton shootBtn;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        rbSpaceship = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //controles
        MovePlayer();

        //shootBtn.onClick.AddListener(ShootBullet);
        if (pressed) ShootBullet();
    }

    private void MovePlayer()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        rbSpaceship.MovePosition(rbSpaceship.position + new Vector2(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
    }

    public void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            gameManager.lives--;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        ((IPointerUpHandler)shootBtn).OnPointerUp(eventData);
        pressed = true;
        Debug.Log("Presiona");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ((IPointerDownHandler)shootBtn).OnPointerDown(eventData);
        pressed = false;
        Debug.Log("Suelta");
    }
}
