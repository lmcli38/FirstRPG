using UnityEngine;

[CreateAssetMenu(fileName = "AirBlade", menuName = "Data/Item effect/AirBlade")]
public class AirBlade_Effect : ItemEffect
{
    [SerializeField] GameObject AirBladePrefab;
    [SerializeField] float xVelocity;
    public ScriptableObject modification;
    public override void ExecuteEffect(Transform _respawnPosition)
    {
        Player player = PlayerManager.instance.player;

        bool thirdAttack = player.attack0.comboCounter == 2;
        if (thirdAttack)
        {
            Debug.Log(modification);
            GameObject airBlade = Instantiate(AirBladePrefab, _respawnPosition.position, player.transform.rotation);
            if(modification != null && modification is Modification)
            {
                ((Modification)modification).ApplyModification(airBlade);
            }
            
            airBlade.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity * player.facingDir, 0);
       
            Destroy(airBlade, 3);
        }
    }
    /*
    public override void ExecuteEffect(Transform playerTransform)
    {
        attackcounter++;

        if (attackcounter % attackThreshold == 0) 
        {
            for (int i = 0; i < 1 + additionalCasts; i++)
            {

                Vector2 spawnPosition = playerTransform.position + playerTransform.right * 1.5f; // Adjust the distance as needed

                // Instantiate the AirBladePrefab at the calculated position
                GameObject newAirBlade = Instantiate(AirBladePrefab, spawnPosition, Quaternion.identity);

                Rigidbody2D rb = newAirBlade.GetComponent<Rigidbody2D>();


                if (rb != null) // Make sure Rigidbody2D component exists
                {
                    // Setup the AirBlade properties
                    Vector2 dir = CalculateDirection(playerTransform);
                    float gravityScale = 0;
                    rb.velocity = dir * moveSpeed;
                    rb.gravityScale = gravityScale;

                    if (playerTransform.GetComponent<Rigidbody2D>().velocity.x < 0)
                    {
                        newAirBlade.transform.localScale = new Vector3(-1f, 1f, 1f);
                    }
                }
                else
                {
                    Debug.LogError("Rigidbody2D component not found on AirBladePrefab.");
                }


                Destroy(newAirBlade, 3f);
                }
            }
        Debug.Log(AirBladePrefab);
    }


    Vector2 CalculateDirection(Transform playerTransform)
    {
        //Return the direction vector based on player's facing direction
        return new Vector2(Mathf.Sign(playerTransform.GetComponent<Rigidbody2D>().velocity.x), 0f);
    }*/

}
