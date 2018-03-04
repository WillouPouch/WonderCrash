﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionPnj : MonoBehaviour
{
    public int id;
    public GameObject door;
    private bool[] hasTalked = new bool[] { false,false,false };

    private int minDistToTalk = 20;
    private GameObject player;
    private List<Interaction> qList;

    public GameObject panel, canvasDialogue, panelInfo;
    private Interaction qCourante, qSuivante;
    private List<Rep> reponsesQuestion;

    private DialogueManager dm;
    private PlayerController pc;
    private Scene currentScene;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dm = canvasDialogue.GetComponent<DialogueManager>();
        pc = player.GetComponent<PlayerController>();
        currentScene = SceneManager.GetActiveScene();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasTalked[pc.getCurrentCharacter() - 1] == false)
        {
            panelInfo.SetActive(true);
            panelInfo.GetComponentInChildren<Text>().text = "E pour interagir";
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasTalked[pc.getCurrentCharacter() - 1] == false)
        {
            panelInfo.SetActive(true);
            panelInfo.GetComponentInChildren<Text>().text = "E pour interagir";
        }
        if (other.gameObject.tag == "Player" && hasTalked[pc.getCurrentCharacter() - 1] == true)
        {
            panelInfo.SetActive(false);
            panelInfo.GetComponentInChildren<Text>().text = "E pour interagir";
        }
        if (Input.GetKeyDown(KeyCode.E) && hasTalked[pc.getCurrentCharacter()-1] == false)
        {
            panel.SetActive(true);

            int currentCharacter = pc.getCurrentCharacter();
            qList = dm.GetDialogue(currentScene.buildIndex - 1, id, currentCharacter);
            qCourante = qList[0];
            dm.setButtonQuestion(qCourante.interaction);
            reponsesQuestion = qCourante.reponseListe;
            dm.AfficheDialogue(qCourante, qList);
            hasTalked[pc.getCurrentCharacter()-1] = true;
            panelInfo.SetActive(false);
        }
        if (dm.GetProgress() == "OK") {
            door.GetComponent<DoorPivoter>().SwitchDoor_Bis();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dm.SetProgress("WAIT");
            panelInfo.SetActive(false);
            panelInfo.GetComponentInChildren<Text>().text = "";

            /*if (dm.GetProgress() == "OK")
            {
                door.GetComponent<DoorPivoter>().SwitchDoor();
            }*/
        }

    }
}
