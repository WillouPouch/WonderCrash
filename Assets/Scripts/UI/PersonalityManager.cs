﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalityManager : MonoBehaviour {

    public GameObject panel;
    public Text titre, nom, profession, age, description, atout, handicap, bouton;


    public void FichePerso(int idPerso) {
        Personality perso = Personalities.GetPerso(idPerso);

        titre.text = perso.titre;
        nom.text = perso.nom;
        profession.text = perso.profession;
        age.text = perso.age;
        description.text = perso.description;
        atout.text = perso.atout;
        handicap.text = perso.handicap;
        bouton.text = perso.bouton;
    }
}