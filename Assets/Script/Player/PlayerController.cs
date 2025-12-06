using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem EnemyEffect;
    private Animator anim;
    private SphereCollider attackCollider;
    private float attackTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator> ();
        attackCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x !=  0f || z != 0f)
        {
            anim.SetBool("IsRun" , true);
            transform.position += new Vector3(x, 0, z) * Time.deltaTime * 5.0f;
        }
        else
        {
            anim.SetBool("IsRun" , false);
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("DoAttack");
            attackCollider.enabled = true;
        }

        if(attackCollider.enabled) {
            
            attackTime += Time.deltaTime;
            if(attackTime > 0.5f)
            {
                attackTime = 0.0f;
                attackCollider.enabled = false;
            }
                
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(EnemyEffect,other.transform.position, Quaternion.identity);
        }
    }

}
