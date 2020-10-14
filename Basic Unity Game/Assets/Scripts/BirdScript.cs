using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    private Vector3 _startingPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower;

    private void Awake()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        var line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, _startingPosition);
        

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 20 ||
            transform.position.y < -20 ||
            transform.position.x > 20 ||
            transform.position.x < -20 ||
            _timeSittingAround > 3)
        {
            var currentSceneName = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        var line = GetComponent<LineRenderer>();
        line.enabled = true;

        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;
    }

    public void OnMouseUp()
    {
        var line = GetComponent<LineRenderer>();
        line.enabled = false;

        var directionToInitialPosition = _startingPosition - transform.position;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var ridgidBody = GetComponent<Rigidbody2D>();

        spriteRenderer.color = Color.white;
        ridgidBody.AddForce(directionToInitialPosition * _launchPower);
        ridgidBody.gravityScale = 1;
        _birdWasLaunched = true;
    }

    public void OnMouseDrag()
    {
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = transform.position.z;

        transform.position = newPos;
    }
}
