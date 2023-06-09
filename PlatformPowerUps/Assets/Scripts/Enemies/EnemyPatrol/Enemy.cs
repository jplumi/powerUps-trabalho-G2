using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] public float speed = 0f;
    [SerializeField] private LayerMask _groundLayer;
    //[SerializeField] private int _health = 0;
    [SerializeField] private GameObject _dropableItem;

    public int damage = 0;

    private Rigidbody2D RB;

    private Direction _direction = Direction.LEFT;
    private Vector2 _vectorDirection;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        _vectorDirection = Vector2.left;
    }

    void FixedUpdate()
    {
        Move();
        CheckWallHit();
        CheckCliff();
    }

    void Move()
    {
        if (_direction.Equals(Direction.RIGHT))
            RB.velocity = new Vector2(speed, RB.velocity.y);
        else
            RB.velocity = new Vector2(-speed, RB.velocity.y);
    }

    void Flip()
    {
        if (RB.velocity.y == 0)
        {
            if(_direction.Equals(Direction.LEFT))
            {
                _direction = Direction.RIGHT;
                _vectorDirection = Vector2.right;
                transform.Rotate(0, 180, 0);
            }
            else
            {
                _direction = Direction.LEFT;
                _vectorDirection = Vector2.left;
                transform.Rotate(0, 180, 0);
            }
        }
    }

    void CheckWallHit()
    {
        float raycastDistance = 1f;
        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, _vectorDirection, raycastDistance, _groundLayer);

        if (wallHit)
            Flip();
    }

    void CheckCliff()
    {
        float raycastDistance = 1.6f;
        Vector2 raycastOrigin = (Vector2) transform.position + _vectorDirection;

        RaycastHit2D groundHit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, _groundLayer);

        if (!groundHit)
            Flip();
    }

    public void TakeDamage(int amount)
    {
        //_enemyHealth.TakeDamage(amount);
        //if(_enemyHealth.currentHealth == 0)
        //{
        //    Die();
        //}
        //Debug.Log("Enemy Health: " + _enemyHealth.currentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
        DropItem();

    }

    private void DropItem()
    {
        if(_dropableItem != null)
        {
            DoubleJumpPowerUp doubleJumpPowerUp;
            if(_dropableItem.TryGetComponent(out doubleJumpPowerUp))
            {
                doubleJumpPowerUp.powerUpTime = 2000f;
            }
            Instantiate(_dropableItem, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _vectorDirection);

        Gizmos.color = Color.green;
        Gizmos.DrawRay((Vector2) transform.position + _vectorDirection, Vector2.down * 1.6f);
    }
}

enum Direction { RIGHT, LEFT };
