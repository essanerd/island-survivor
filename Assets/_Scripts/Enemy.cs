
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;

    private Rigidbody2D _rb2d;
    private Transform _playerTransform;

    public bool Stopped = false;

    [SerializeField]
    private GameObject _crabDead;

    public event Action OnDie;

    // Start is called once before the first execution of Update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Stopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Stopped || _playerTransform == null)
        {
            _rb2d.velocity = Vector2.zero;
            return;
        }

        Vector3 directionToPlayer =
            _playerTransform.position - transform.position;

        _rb2d.velocity = directionToPlayer.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            Instantiate(_crabDead, transform.position, Quaternion.identity);

            Destroy(gameObject);

            if (OnDie != null)
            {
                OnDie();
            }
        }
    }
}
