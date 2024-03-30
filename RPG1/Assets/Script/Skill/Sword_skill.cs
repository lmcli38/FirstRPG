using UnityEngine;

public class Sword_skill : Skill
{
    [Header("Skill info")]
    [SerializeField] GameObject swordPrefabs;
    [SerializeField] Vector2 launchForce;
    [SerializeField] float swordGravity;

    Vector2 finalDir;

    GameObject[] dots;
    protected override void Start()
    {
        base.Start();

    }
    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            finalDir = new Vector2(player.facingDir * launchForce.x, 0);
        }
        
    }

    public void CreateAirBlade()
    {
        GameObject newSword = Instantiate(swordPrefabs, player.transform.position, transform.rotation);
        AirBlade_AC newAirBlade = newSword.GetComponent<AirBlade_AC>();
        
        if (finalDir.x < 0)
        {
            // If facing left, flip the air blade
            newSword.transform.localScale = new Vector3(-1f, 1f, 0f);
        }

        newAirBlade.SetupAirBlade(finalDir, swordGravity,player);
    }




}
