using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour, Characterable
{



    private string _name;
    public string Name  // read-write instance property
    {
        get => _name;
        set => _name = value;
    }
    [SerializeField]
    private float _health;
    public float Health  // read-write instance property
    {
        get => _health;
        set => _health = value;
    }

    private float _maxspeed;
    public float MaxSpeed  // read-write instance property
    {
        get => _maxspeed;
        set => _maxspeed = value;
    }

    private float _acceleration;
    public float Acceleration  // read-write instance property
    {
        get => _acceleration;
        set => _acceleration = value;
    }

    private Weaponable _weapon;
    public Weaponable weapon { get { return _weapon; } set{ _weapon = value; } }

    //private Weaponable _weapon;
    //public Weaponable Weapon  // read-write instance property
    //{
    //    get => _weapon;
    //    set => _weapon = value;
    //}

    public Controllable controller;
    public Animator playerAnimation;

    public float maxSpeed = 10; //m/s
    public float acceleration = 5; //m/s^2
    public float deceleration = 20;

    public float lockOnDistance;

    private Camera cam;

    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        
    }
    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        Movement();
        if (controller.InputX())
        {
            if(weapon != null)
            {
                weapon.StartAttack();
            }
        }
    }

    public void Movement()
    {
        float curSpeed = Vector3.Magnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z));
        playerAnimation.SetFloat("speed", curSpeed);
        float facing = Camera.main.transform.eulerAngles.y;
        Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * new Vector3(controller.Joystick1().x, 0, controller.Joystick1().y);

        if (curSpeed < maxSpeed)
        {
            if (myTurnedInputs != Vector3.zero)
            {
                Vector3 movment = (new Vector3(myTurnedInputs.x * acceleration * Time.deltaTime, 0, myTurnedInputs.z * acceleration * Time.deltaTime));
                Vector3 xzVector = rb.velocity;
                xzVector.y = 0;
                rb.velocity = rb.velocity + movment + ((myTurnedInputs - xzVector.normalized) * (deceleration * Time.deltaTime));
            }
            else
            {
                Vector3 movment = (new Vector3(myTurnedInputs.x * acceleration * Time.deltaTime, 0, myTurnedInputs.z * acceleration * Time.deltaTime));
                Vector3 xzVector = rb.velocity;
                xzVector.y = 0;
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
        //rb.AddForce(new Vector3(controller.Joystick1().x * acceleration * Time.deltaTime, 0, controller.Joystick1().y * acceleration * Time.deltaTime));
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        if (enemys.Length > 0)
        {
            Enemy closeEnemy = enemys[0];

            float d = Vector3.Distance(enemys[0].transform.position, this.transform.position);
            for (int i = 1; i < enemys.Length; i++)
            {
                d = Vector3.Distance(enemys[i].transform.position, this.transform.position);
                if (d <= lockOnDistance && d < Vector3.Distance(closeEnemy.transform.position, this.transform.position))
                {
                    closeEnemy = enemys[i];
                }
            }
            if (d <= lockOnDistance)
            {
                transform.LookAt(new Vector3(closeEnemy.transform.position.x, transform.position.y, closeEnemy.transform.position.z));
            }
            else
            {
                transform.LookAt(transform.position + myTurnedInputs);
            }
        }else
        {
            transform.LookAt(transform.position + myTurnedInputs);
        }
    }

    public void getDamage(float damage)
    {

    }


    public void Attack()
    {
        
    }

    private void CheckHealth()
    {
        if(Health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
