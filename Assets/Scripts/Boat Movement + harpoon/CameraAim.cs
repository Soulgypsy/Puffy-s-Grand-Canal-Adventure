using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAim : MonoBehaviour
{

    [Header("Harpoon Aiming")]
    public Transform target;
    public Transform defaultTarget;
    private Camera cam;
    public float rayDistance;
    public LayerMask layer;
    public SelectionManager currentTarget;
    private UiManager UiManager;

    [Header("Firing")]
    public GameObject harpoonPrefab;
    [SerializeField] private GameObject currentHarpoon;
    public Transform spawnPoint;
    public bool readyToFire = true;
    public bool harpoonOff;
    public float harpoonMaxDist;

    [Header("Harpoon Speed Values")]
    public float launchSpeed;
    public float returnSpeed;

    [Header("Moving Towards Harpoon")]
    [SerializeField] private bool hit;
    public HarpoonBoatMovement movement;

    [Header("Collectables")]
    public Transform collecionArea;
    public bool Stored;

    [Header("Audio")]
    public AudioClip harpoonHit;
    public AudioClip reelBack;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        UiManager = GameObject.FindGameObjectWithTag("UIManagerMain").GetComponent<UiManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) & readyToFire == true & Time.deltaTime != 0 & harpoonOff == false)
        {
            Fire();
            readyToFire = false;
        }
        else if (Input.GetMouseButtonUp(0) & readyToFire == false)
        {
            currentHarpoon.GetComponent<Harpoon>().ReturnToBoat();
        }


        if (target != null)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.LookAt(new Vector3(defaultTarget.position.x, transform.position.y, defaultTarget.position.z));
        }   
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //Raycast checking for valid objects.
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, layer)) //Over Hookable
        {
            currentTarget = hitInfo.collider.GetComponent<SelectionManager>();
            target = hitInfo.collider.GetComponent<SelectionManager>().harpoonLockPos;

           UiManager.changeToAimCursor();
        }
        else if (currentTarget != null) //Off Hookable
        {
            target = null;
            currentTarget.selectedMarker.SetActive(false);
            currentTarget = null;

            UiManager.changeToDefaultCursor();
        }
    }
    public void Fire()
    {
        var harpoon = Instantiate(harpoonPrefab, spawnPoint.position, spawnPoint.rotation);
        harpoon.GetComponent<Rigidbody>().velocity = spawnPoint.forward * launchSpeed;
        currentHarpoon = harpoon;
    }
    public void HarpoonHit()
    {
        movement.Actived(currentHarpoon);
        audioSource.PlayOneShot(harpoonHit);
    }
    public void HarpoonDead()
    {
        readyToFire = true;    
        movement.moving = false;
    }

    
}
