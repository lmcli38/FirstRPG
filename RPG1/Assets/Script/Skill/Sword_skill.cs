using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword_skill : Skill
{
    [Header("Skill info")]
    [SerializeField] GameObject swordPrefabs;
    [SerializeField] Vector2 launchForce;
    [SerializeField] float swordGravity;

    Vector2 finalDir;

    [Header("Aim dots")]
    [SerializeField] int numberOfDots;
    [SerializeField] float spaceBetweenDots;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] Transform dotsParent;

    GameObject[] dots;
    protected override void Start()
    {
        base.Start();

        //GenereateDot();
    }
    protected override void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            finalDir = new Vector2 (AimDirection().normalized.x * launchForce.x,0);
        }
        /*if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            for(int i = 0; i < dots.Length; i++) 
            {
                dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
            }
        }*/

    }

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefabs, player.transform.position, transform.rotation);
        SwordSkill_AC newSwordScript = newSword.GetComponent<SwordSkill_AC>();

        newSwordScript.SetUPSword(finalDir, swordGravity);

        //DotsActive(false);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return  direction;
    }
    /*public void DotsActive(bool _isActive)
    {
        for (int i = 0; i < dots.Length; i++) 
        {
            dots[i].SetActive(_isActive);
        }
    }
   
    private void GenereateDot()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i <numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosition(float t)
    {
        Vector2 position = (Vector2)player.transform.position + new Vector2(
            AimDirection().normalized.x * launchForce.x,
            AimDirection().normalized.y * launchForce.y) * t + .5f * (Physics2D.gravity * swordGravity) * (t * t);
        return position;
    }
    */
}
