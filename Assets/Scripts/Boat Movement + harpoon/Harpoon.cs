

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [Header("Returning To Boat")]
    [SerializeField] private float fireTimer;
    [SerializeField] private float timeAlive;
    [SerializeField] private GameObject launcher;
    [SerializeField] private CameraAim cameraAim;
    public float returnSpeed;
    public float distance;
    private float maxDistance;
    private bool returning;

    [Header("Hitting Rocks")]
    [SerializeField] private bool timerOn = true;
    private bool stopLooking;
    public Rigidbody rb;
    public GameObject currentRock;

    [Header("Collecting Iteams")]
    [SerializeField] bool collected;

    [Header("Rope")]
    public Transform ropePosition;
    [SerializeField] private Rope rope;

    [Header("Particles")]
    public ParticleSystem hitParticle;

    private void Awake()
    {
        FindBoat();
        SetRope();
        returnSpeed = cameraAim.returnSpeed;
        maxDistance = cameraAim.harpoonMaxDist;
    }

    void timer()
    {
        distance = Vector3.Distance(launcher.transform.position, transform.position);

        if (distance > maxDistance)
        {
            rb.velocity = Vector3.zero;
            ReturnToBoat();
        }
    }

    private void Update()
    {
        timer();
        transform.up = -(launcher.transform.position - transform.position);

        if (stopLooking == true)
        {
            rb.velocity = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, launcher.transform.position, returnSpeed * Time.deltaTime);
        }
    }

    public void FindBoat()
    {
        launcher = GameObject.FindGameObjectWithTag("HarpoonLauncher"); 
        cameraAim = launcher.GetComponent<CameraAim>();
    }

    private void OnTriggerEnter(Collider other) //Hitiing the boats collection collider.
    {
        if (other.tag == "PlayerBoat" & returning == true || stopLooking == true)
        {
            DestroyHarpoon();
        }
    }

    private void OnCollisionEnter(Collision collision) //Hitting rocks and other harpoonable objects.
    {
        if (collision.gameObject.tag == "Hookable" & stopLooking == false)
        {
            timerOn = false;
            Destroy(rb);
            cameraAim.HarpoonHit(); 
            activateParticles();
            currentRock = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Collectable" & collected == false)
        {
            timerOn = false;
            transform.SetParent(collision.transform);
        }       
    }

    public void ReturnToBoat()
    {
        if (timerOn == false)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            stopLooking = true;
            returning = true;
        }
        else //Returning after hitting nothing
        {
            stopLooking = true;
            cameraAim.audioSource.volume = 1;
            cameraAim.audioSource.PlayOneShot(cameraAim.reelBack);
        }
    }

    public void DestroyHarpoon()
    {
        cameraAim.HarpoonDead();
        rope.makeInvisble();
        cameraAim.audioSource.Stop();
        cameraAim.audioSource.volume = 0.4f;
        Destroy(gameObject);
    }

    public void SetRope()
    {
        rope = GameObject.FindGameObjectWithTag("Rope").GetComponent<Rope>();
        rope.makeVisable();
        rope.harpoonLink = ropePosition;
    }

    public void activateParticles()
    {
        hitParticle.Play();
        ParticleSystem.EmissionModule em = hitParticle.emission;
        em.enabled = true;
    }
    
}

