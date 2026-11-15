using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]


public class touch : MonoBehaviour
{
    public bool a = true, b = false;
    public float speed, x, y, l;
    private Vector3 screenPoint;
    private Vector3 offset;

    void FixedUpdate()
    {
        if(!Input.GetMouseButton(0) && !b)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        b = false;
    }



    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        x = (curPosition.x - transform.position.x) * (curPosition.x - transform.position.x);
        y = (curPosition.y - transform.position.y) * (curPosition.y - transform.position.y);
        l = Mathf.Sqrt(x + y);
        if (speed < 10)
            speed = l * 5;
        else
            speed = 10;
        if (l < 0.2)
        {
            if (a)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                a = false;
            }
            transform.position = Vector3.Lerp(transform.position, curPosition, Time.deltaTime * speed);
        }
        else
            GetComponent<Rigidbody2D>().AddForce((curPosition - transform.position) * speed, ForceMode2D.Force);
        if (!a)
            a = true;

    }
}
