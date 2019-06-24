using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Unit target;
    public int damage;
    public float speed = 10f;

    private void Start()
    {
        SetRotation();
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        if(target.isDead)
            Destroy(this.gameObject);

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        if(target)
            transform.position = Vector2.MoveTowards(transform.position,new Vector3(target.transform.position.x, target.transform.position.y+1f), step);
    }

    public void SetValue(Unit _target, int _damage)
    {
        target = _target;
        damage = _damage;
    }

    public void SetValue(Unit _target, int _damage, float _speed)
    {
        target = _target;
        damage = _damage;
        speed = _speed;
    }

    public void SetRotation()
    {
        if (target)
        {
            Vector3 relativePos = new Vector3(target.transform.position.x, target.transform.position.y + 1f) - transform.position;
            relativePos.Normalize();

            float rot_z = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == target.gameObject)
        {
            collision.gameObject.GetComponent<Unit>().TakeDamage(damage);
            Destroy(this.gameObject,0.1f);
        }
    }
}
