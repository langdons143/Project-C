using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 30f;
    public float shootingCooldown = 0.5f;

    public Camera playerCamera;

    AudioManager audioManager;

    private float timer;

    /*private void Awake()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
    }*/

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= shootingCooldown &&!GameTimer.instance.gameEnded)
        {
            Shoot();
            timer = 0f;
        }
    }

    public void Shoot()
    {
        // Create a ray from the center of the camera
        Ray ray = playerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        RaycastHit hit;
        Vector3 targetPoint;

        // Check if the crosshair is pointing at something
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100f);
        }

        // Calculate the direction of the bullet
        Vector3 direction = (targetPoint - bulletSpawnPoint.position).normalized;

        // Spawn the bullet
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawnPoint.position,
            Quaternion.LookRotation(direction)
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = direction * bulletSpeed;

        Destroy(bullet, 0.5f);
    }
}