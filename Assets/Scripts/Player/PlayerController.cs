﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4.0f;
    private int[] characters;
    private UnityEngine.UI.Image mainIcon;
    Character characterComponenet;
    private Vector3 movment;
    PlayerStats stats;
    public float RandomChangePeriode = 3f;

    // Use this for initialization
    void Start()
    {
        characters = new int[] { 1, 2, 3 };
        characterComponenet = GetComponent<Character>();
        mainIcon = GameObject.FindGameObjectWithTag("Icon0").GetComponent<UnityEngine.UI.Image>();
        characterComponenet.setCharacter(characters[0]);
        mainIcon.sprite = characterComponenet.getCurrentSprite();
        GameObject.FindGameObjectWithTag("Icon" + 1).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(characters[1]);
        GameObject.FindGameObjectWithTag("Icon" + 2).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(characters[2]);
        stats = GetComponent<PlayerStats>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!stats.isCrazy())
        {
            changeCharacter();
        }
        else
        {
            
        }

        float h = 0f;
        float v = 0f;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (!stats.getSpotted())
        {
            Move(h, v);

        }

    }

    void Move(float h, float v)
    {
        movment.Set(h, 0f, v);
        movment = movment.normalized * speed * Time.deltaTime;
        transform.Translate(movment);
    }

    int findIndexOf(int character)
    {
        if (characters[0] == character)
            return 0;
        else if (characters[1] == character)
            return 1;
        else
            return 2;
    }

    public int[] getCharacters()
    {
        return characters;
    }

    public int getCurrentCharacter()
    {
        return characters[0];
    }

    void changeCharacter()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && characters[0] != 1)
        {
            getCharacter(1);
            stats.incrCraziness(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && characters[0] != 2)
        {
            getCharacter(2);
            stats.incrCraziness(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && characters[0] != 3)
        {
            getCharacter(3);

            // Police man get the player crazy faster 
            stats.incrCraziness(2);
        }

    }

    void getCharacter(int character)
    {
        int lastCharacter = characters[0];
        int index = findIndexOf(character);
        characters[findIndexOf(character)] = lastCharacter;
        characters[0] = character;
        characterComponenet.setCharacter(character);
        mainIcon.sprite = characterComponenet.getCurrentSprite();
        GameObject.FindGameObjectWithTag("Icon" + index).GetComponent<UnityEngine.UI.Image>().sprite = characterComponenet.getSpriteByCharacter(lastCharacter);
    }

    public IEnumerator RandomChange()
    {
        yield return new WaitForSeconds(RandomChangePeriode);
        int character = Random.Range(1, 4);
        while (character == characters[0])
        {
            character = Random.Range(1, 3);
        }
        getCharacter(character);

        StartCoroutine(RandomChange());
    }
}