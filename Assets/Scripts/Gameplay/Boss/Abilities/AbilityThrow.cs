using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityThrow : MonoBehaviour
{
    Rigidbody2D rigBody;

    [SerializeField] GameObject explosionObject;

    // Start is called before the first frame update
    void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();

        Launch(new Vector2(-7,-2));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Instantiate(explosionObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Launch(Vector2 target)
    {
        float angle = 60;

        Vector2 toPos = (Vector2)transform.position - target;
        float h = toPos.y;
        toPos.y = 0;
        float r = toPos.magnitude;
        float g = -Physics.gravity.y;
        float a = Mathf.Deg2Rad * angle;
        float vI = Mathf.Sqrt(((Mathf.Pow(r, 2f) * g)) / (r * Mathf.Sin(2f * a) + 2f * h * Mathf.Pow(Mathf.Cos(a), 2f)));
        Vector2 velocity = (target - (Vector2)transform.position).normalized * Mathf.Cos(a);
        velocity.y = Mathf.Sin(a);



        rigBody.velocity = velocity * vI;

    }
}