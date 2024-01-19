using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private BoxCollider2D boxCollider2D;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Lep_Kid").transform;
    }

    void Update()
    {
        if (player.transform.position.x >= -7)
        {
            Vector3 pos = transform.position;
            pos.x = player.transform.position.x + 5.3f;
            transform.position = pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            boxCollider2D.isTrigger = false;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            boxCollider2D.isTrigger = true;
        }
    }
}
