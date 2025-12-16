using UnityEngine;

public class Player : Damageable
{
    #region Declarations
    [SerializeField] private float speed = 1;
    Vector3 destination;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float pewpewRate = 1;

    [SerializeField] private int playerDamage = 1;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        InvokeRepeating("PewPew", 0, pewpewRate);
    }
    void Update()
    {
        Movement(); 
    }
    void FixedUpdate()
    {
        Vector3 positionInBetween = Vector3.Lerp(transform.position, destination, speed*Time.fixedDeltaTime);
        transform.position = positionInBetween; //A  e  C  retorna B  
    }
    #endregion
    void PewPew()
    {
        Bullet newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newbullet.SetDamage(playerDamage);
    }
    public void Increment(StatType stat)
    {
        if(stat == StatType.Damage)
        {
            playerDamage++;            
        }
        if(stat == StatType.Speed)
        {
            
        }

    }
    void Movement()
    {
        Camera cam = Camera.main;
        
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(
                touch.position.x,
                touch.position.y,
                cam.nearClipPlane  
            ));

            worldPos.z = transform.position.z;

            destination = worldPos;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            worldPos.z = transform.position.z;

            destination = worldPos;
        }
    }
}
