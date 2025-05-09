using System.Collections;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;    
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    
    
}
