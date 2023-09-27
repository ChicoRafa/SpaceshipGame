using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minRotateSpeed = 45f, maxRotateSpeed = 80f;
    private float currentRotateSpeed;
    public float minGravityScale = 0.2f, maxGravityScale = 0.6f;
    private float currentGravityScale;
    public float minScale = 5, maxScale = 10;
    private float currentScale;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeAsteroid();
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, currentRotateSpeed * Time.deltaTime));
    }

    private void RandomizeAsteroid()
    {
        //velocidad de rotaci�n
        currentRotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        //gravedad (velocidad de ca�da)
        currentGravityScale = Random.Range(minGravityScale, maxGravityScale);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = currentGravityScale;
        //escala (tama�o)
        currentScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
