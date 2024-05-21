using UnityEngine;

[CreateAssetMenu(fileName = "AirBlade", menuName = "Data/Item effect/AirBlade")]
public class AirBlade_Effect : ItemEffect
{
    [SerializeField] GameObject AirBladePrefab;
    [SerializeField] float xVelocity;

    public Modification[] modifiers;
    public override void ExecuteEffect(Transform _respawnPosition)
    {
        Player player = PlayerManager.instance.player;

        bool thirdAttack = player.attack0.comboCounter == 2;
        if (thirdAttack)
        {
            //Debug.Log(modification);

            GameObject airBlade = Instantiate(AirBladePrefab, _respawnPosition.position, player.transform.rotation);
            /*
            if(itemData != null)
            {
                Debug.Log(itemData.name);
                itemData.ApplyModifications(airBlade);
            }
            
            if(modification != null && modification is Modification)
            {
                Debug.Log("Applying modification directly");
                ((Modification)modification).ApplyModification(airBlade);
            }*/
            foreach (Modification modifier in modifiers) 
            {
                modifier.ApplyModification(airBlade);
            }

            airBlade.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity * player.facingDir, 0);
       
            Destroy(airBlade, 3);
        }
    }
}
