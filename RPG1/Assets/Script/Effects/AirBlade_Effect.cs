using UnityEngine;


[CreateAssetMenu(fileName = "AirBlade", menuName = "Data/Item effect/AirBlade")]
public class AirBlade_Effect : ItemEffect
{
    [SerializeField] GameObject AirBladePrefab;
    float moveSpeed = 5f;

    public override void ExecuteEffect(Transform playerTransform) 
    {
        // Calculate the position in front of the player
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


    Vector2 CalculateDirection(Transform playerTransform)
    {
        // Return the direction vector based on player's facing direction
        return new Vector2(Mathf.Sign(playerTransform.GetComponent<Rigidbody2D>().velocity.x), 0f);
    }

}
