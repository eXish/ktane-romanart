﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using System;

public class RomanArtScript : MonoBehaviour {

    public KMAudio audio;
    public KMBombInfo bomb;

    public KMSelectable[] buttons;

    public GameObject numberdisplay;
    private int[] numbers = {76,125,23,59,7,231,556,82,203};
    private int currentnumber = 0;
    public GameObject[] artpieces;
    private GameObject[] selectedpieces = new GameObject[6];
    private int currentselect = 0;

    private string[] cheers = {"Fancy!","Roma","Clear","Doned"};

    private string step1num;
    private int step2num;

    private ArrayList order = new ArrayList();

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        moduleSolved = false;
        foreach(KMSelectable obj in buttons){
            KMSelectable pressed = obj;
            pressed.OnInteract += delegate () { PressButton(pressed); return false; };
        }
    }

    void Start () {
        if(bomb.GetStrikes() != 3)
        {
            randomizePieces();
            hideAllButSelected();
            randomizeNumber();
            performStep1();
            performStep2();
            performStep3();
        }
    }

    void PressButton(KMSelectable pressed)
    {
        if(moduleSolved != true)
        {
            pressed.AddInteractionPunch(0.5f);
            if (pressed.name.Equals("buttonRight"))
            {
                selectedpieces[currentselect].SetActive(false);
                currentselect++;
                if(currentselect >= 6)
                {
                    currentselect = 0;
                }
                selectedpieces[currentselect].SetActive(true);
                GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            }
            else if (pressed.name.Equals("buttonLeft"))
            {
                selectedpieces[currentselect].SetActive(false);
                currentselect--;
                if (currentselect <= -1)
                {
                    currentselect = 5;
                }
                selectedpieces[currentselect].SetActive(true);
                GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            }
            else if (pressed.name.Equals("displayArt"))
            {
                int comparer = 0;
                foreach(int s in order)
                {
                    comparer = s;
                    break;
                }
                if ((currentselect + 1) == comparer)
                {
                    order.RemoveAt(0);
                    Debug.LogFormat("[Roman Art #{0}] Piece {1} Pressed, correct", moduleId, currentselect+1);
                    if(order.Count != 0)
                    {
                        audio.PlaySoundAtTransform("paintsound", transform);
                    }
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    audio.PlaySoundAtTransform("paintsound", transform);
                    order.Clear();
                    selectedpieces = new GameObject[6];
                    Debug.LogFormat("[Roman Art #{0}] Piece {1} Pressed, incorrect", moduleId, currentselect + 1);
                    Debug.LogFormat("[Roman Art #{0}] Resetting Module...", moduleId);
                    currentselect = 0;
                    Start();
                }
                if (order.Count == 0)
                {
                    GetComponent<KMBombModule>().HandlePass();
                    numberdisplay.GetComponentInChildren<TextMesh>().text = randomCheer();
                    Debug.LogFormat("[Roman Art #{0}] All Pieces Pressed Correctly, Module Disarmed.", moduleId, comparer);
                    moduleSolved = true;
                    int decider = randomVictory();
                    switch (decider)
                    {
                        case 0:
                            audio.PlaySoundAtTransform("victory", transform);
                            break;
                        case 1:
                            audio.PlaySoundAtTransform("victory1", transform);
                            break;
                        case 2:
                            audio.PlaySoundAtTransform("victory2", transform);
                            break;
                        default: break;
                    }
                }
            }
        }
    }

    private void performStep1()
    {
        step1num = "";
        switch (currentnumber)
        {
            case 76:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "4";
                }
                if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "9";
                }
                if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "3";
                }
                if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "8";
                }
                if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "6";
                }
                if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "1";
                }
                if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "2";
                }
                if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "2";
                }
                if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "6";
                }
                if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "1";
                }
                if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "8";
                }
                if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "3";
                }
                if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "9";
                }
                if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "1";
                }
                if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "4";
                }
                if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "9";
                }
                if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "6";
                }
                if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "3";
                }
                if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "7";
                }
                if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "5";
                }
                break;
            case 125:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "7";
                }
                break;
            case 23:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "5";
                }
                break;
            case 59:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "3";
                }
                break;
            case 7:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "6";
                }
                break;
            case 231:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "5";
                }
                break;
            case 556:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "3";
                }
                break;
            case 82:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "5";
                }
                break;
            case 203:
                if (selectedpieces.Contains(artpieces[27]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[20]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[21]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[4]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[13]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[2]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[9]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[6]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[10]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[11]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[8]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[29]))
                {
                    step1num += "4";
                }
                 if (selectedpieces.Contains(artpieces[12]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[7]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[5]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[23]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[28]))
                {
                    step1num += "1";
                }
                 if (selectedpieces.Contains(artpieces[14]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[17]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[16]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[15]))
                {
                    step1num += "5";
                }
                 if (selectedpieces.Contains(artpieces[18]))
                {
                    step1num += "7";
                }
                 if (selectedpieces.Contains(artpieces[22]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[0]))
                {
                    step1num += "9";
                }
                 if (selectedpieces.Contains(artpieces[1]))
                {
                    step1num += "3";
                }
                 if (selectedpieces.Contains(artpieces[19]))
                {
                    step1num += "2";
                }
                 if (selectedpieces.Contains(artpieces[24]))
                {
                    step1num += "6";
                }
                 if (selectedpieces.Contains(artpieces[26]))
                {
                    step1num += "8";
                }
                 if (selectedpieces.Contains(artpieces[25]))
                {
                    step1num += "0";
                }
                 if (selectedpieces.Contains(artpieces[3]))
                {
                    step1num += "2";
                }
                break;
            default:
                break;
        }
        Debug.LogFormat("[Roman Art #{0}] The 6-Digit Number Generated from Step 1 is {1}", moduleId, step1num);
    }

    private void performStep2()
    {
        string step2 = "";
        string modSerial = bomb.GetSerialNumber();

        modSerial = modSerial.Replace('A', '3');
        modSerial = modSerial.Replace('B', '7');
        modSerial = modSerial.Replace('C', '0');
        modSerial = modSerial.Replace('D', '7');
        modSerial = modSerial.Replace('E', '8');
        modSerial = modSerial.Replace('F', '6');
        modSerial = modSerial.Replace('G', '2');
        modSerial = modSerial.Replace('H', '5');
        modSerial = modSerial.Replace('I', '1');
        modSerial = modSerial.Replace('J', '9');
        modSerial = modSerial.Replace('K', '6');
        modSerial = modSerial.Replace('L', '8');
        modSerial = modSerial.Replace('M', '0');
        modSerial = modSerial.Replace('N', '1');
        modSerial = modSerial.Replace('O', '1');
        modSerial = modSerial.Replace('P', '7');
        modSerial = modSerial.Replace('Q', '4');
        modSerial = modSerial.Replace('R', '5');
        modSerial = modSerial.Replace('S', '3');
        modSerial = modSerial.Replace('T', '1');
        modSerial = modSerial.Replace('U', '9');
        modSerial = modSerial.Replace('V', '5');
        modSerial = modSerial.Replace('W', '4');
        modSerial = modSerial.Replace('X', '1');
        modSerial = modSerial.Replace('Y', '3');
        modSerial = modSerial.Replace('Z', '6');
        Debug.LogFormat("[Roman Art #{0}] The Modified Serial Number for Step 2 is {1}", moduleId, modSerial);

        int amount = 0;
        int one = 0;
        int two = 0;
        while(amount < 6)
        {
            int.TryParse(modSerial.Substring(amount, 1), out one);
            int.TryParse(step1num.Substring(amount, 1), out two);
            step2 += ((one + two) % 10);
            amount++;
        }
        int.TryParse(step2, out step2num);
        Debug.LogFormat("[Roman Art #{0}] The New Number Received After Calculating Step 2 is {1}", moduleId, step2num);
    }

    private void performStep3()
    {
        string step3Numeral = numberToNumeral(step2num);
        Debug.LogFormat("[Roman Art #{0}] The New Number Encrypted by Step 3 is {1}", moduleId, step3Numeral);

        if((step2num < 100000) && (bomb.IsIndicatorPresent("SND")) && !(selectedpieces.Contains(artpieces[29])))
        {
            order.Add(2);
            order.Add(5);
            if (selectedpieces.Contains(artpieces[17]))
            {
                order.Add((Array.IndexOf(selectedpieces, artpieces[17])+1));
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 2nd piece, 5th piece, and the Statue of David", moduleId);
            }
            else
            {
                order.Add(4);
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 2nd piece, 5th piece, and 4th piece", moduleId);
            }
        }
        else if ((xCounter(step3Numeral) < 3) && (serialHasOdd()))
        {
            order.Add(5);
            order.Add(6);
            order.Add(1);
            order.Add(3);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 5th piece, 6th piece, 1st piece, and 3rd piece", moduleId);
        }
        else if ((step2num > 200000) && (selectedpieces.Contains(artpieces[24])))
        {
            order.Add(6);
            if (selectedpieces.Contains(artpieces[15]))
            {
                order.Add((Array.IndexOf(selectedpieces, artpieces[15]))+1);
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 6th piece and The Pantheon", moduleId);
            }
            else
            {
                order.Add(1);
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 6th piece and 1st piece", moduleId);
            }
        }
        else if ((iCounter(step3Numeral) >= 3) && (bomb.GetBatteryCount() == 0))
        {
            order.Add(4);
            order.Add(2);
            order.Add(1);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 4th piece, 2nd piece, and 1st piece", moduleId);
        }
        else if (step3Numeral.Length <= 5)
        {
            order.Add(3);
            order.Add(2);
            order.Add(5);
            order.Add(2);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 3rd piece, 2nd piece, 5th piece, and 2nd piece", moduleId);
        }
        else if ((selectedpieces.Contains(artpieces[4])) && (selectedpieces.Contains(artpieces[5])))
        {
            order.Add(1);
            order.Add(3);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 1st piece and 3rd piece", moduleId);
        }
        else if ((step2num > 2506) && (bomb.IsPortPresent("DVI")))
        {
            order.Add(3);
            order.Add(6);
            order.Add(5);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 3rd piece, 6th piece, and 5th piece", moduleId);
        }
        else if ((step2num % 5) == 0)
        {
            order.Add(2);
            order.Add(6);
            if (selectedpieces.Contains(artpieces[25]))
            {
                order.Add((Array.IndexOf(selectedpieces, artpieces[25]))+1);
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 2nd piece, 6th piece, and the Head of Medusa", moduleId);
            }
            else
            {
                order.Add(2);
                Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 2nd piece, 6th piece, and 2nd piece", moduleId);
            }
        }
        else if (bomb.GetPortCount() <= 3)
        {
            order.Add(5);
            order.Add(6);
            order.Add(1);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 5th piece, 6th piece, and 1st piece", moduleId);
        }
        else
        {
            order.Add(4);
            order.Add(1);
            order.Add(5);
            order.Add(3);
            Debug.LogFormat("[Roman Art #{0}] The Order the Pieces Should be Pressed in Determined by Step 3 is 4th piece, 1st piece, 5th piece, and 3rd piece", moduleId);
        }
    }

    private int xCounter(string num)
    {
        int xcount = 0;
        char[] nums = num.ToCharArray();
        foreach(char thing in nums)
        {
            if (thing.Equals('X'))
            {
                xcount++;
            }
        }
        return xcount;
    }

    private int iCounter(string num)
    {
        int icount = 0;
        char[] nums = num.ToCharArray();
        foreach (char thing in nums)
        {
            if (thing.Equals('I'))
            {
                icount++;
            }
        }
        return icount;
    }

    private void randomizePieces()
    {
        int amount = 0;
        while (amount != 6)
        {
            int rando = UnityEngine.Random.RandomRange(0, 30);
            if (!selectedpieces.Contains(artpieces[rando]))
            {
                selectedpieces[amount] = artpieces[rando];
                amount++;
            }
        }
        Debug.LogFormat("[Roman Art #{0}] The Art Pieces are: {1}, {2}, {3}, {4}, {5}, and {6}", moduleId, convertObjectToName(selectedpieces[0]), convertObjectToName(selectedpieces[1]), convertObjectToName(selectedpieces[2]), convertObjectToName(selectedpieces[3]), convertObjectToName(selectedpieces[4]), convertObjectToName(selectedpieces[5]));
    }

    private void hideAllButSelected()
    {
        foreach (GameObject obj in artpieces)
        {
            if(obj != selectedpieces[currentselect])
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
        }
    }

    private void randomizeNumber()
    {
        int rando = UnityEngine.Random.RandomRange(0, 9);
        currentnumber = numbers[rando];
        string numeral = numberToNumeral(currentnumber);
        numberdisplay.GetComponentInChildren<TextMesh>().text = numeral;
        Debug.LogFormat("[Roman Art #{0}] The Roman Numeral is {1} ({2})", moduleId, numeral, currentnumber);
    }

    private string numberToNumeral(int num)
    {
        string numeral = "";
        while (num >= 500000)
        {
            num -= 500000;
            numeral += "D(bar)";
        }
        while (num >= 100000)
        {
            num -= 100000;
            numeral += "C(bar)";
        }
        while (num >= 50000)
        {
            num -= 50000;
            numeral += "L(bar)";
        }
        while (num >= 10000)
        {
            num -= 10000;
            numeral += "X(bar)";
        }
        while (num >= 5000)
        {
            num -= 5000;
            numeral += "V(bar)";
        }
        while (num >= 1000)
        {
            num -= 1000;
            numeral += "M";
        }
        while (num >= 500)
        {
            num -= 500;
            numeral += "D";
        }
        while (num >= 100)
        {
            num -= 100;
            numeral += "C";
        }
        while (num >= 50)
        {
            num -= 50;
            numeral += "L";
        }
        while (num >= 10)
        {
            num -= 10;
            numeral += "X";
        }
        while (num >= 5)
        {
            num -= 5;
            numeral += "V";
        }
        while (num >= 1)
        {
            num -= 1;
            numeral += "I";
        }
        return numeral;
    }

    private string convertObjectToName(GameObject obj)
    {
        if (obj.name.Equals("homer"))
        {
            return "Statue of Homer";
        }
        else if (obj.name.Equals("marcuscolumn"))
        {
            return "Column of Marcus Aurelius";
        }
        else if (obj.name.Equals("venus"))
        {
            return "Statue of Capitoline Venus";
        }
        else if (obj.name.Equals("jupitertemple"))
        {
            return "Temple of Jupiter (Lebanon)";
        }
        else if (obj.name.Equals("archtitus"))
        {
            return "The Arch of Titus";
        }
        else if (obj.name.Equals("archconstantine"))
        {
            return "The Arch of Constantine";
        }
        else if (obj.name.Equals("archseverus"))
        {
            return "The Arch of Septimius Severus";
        }
        else if (obj.name.Equals("caesarjbust"))
        {
            return "Bust of Julius Caesar";
        }
        else if (obj.name.Equals("caesarabust"))
        {
            return "Bust of Caesar Augustus";
        }
        else if (obj.name.Equals("circusmaximus"))
        {
            return "The Circus Maximus";
        }
        else if (obj.name.Equals("trajan"))
        {
            return "Statue of Trajan";
        }
        else if (obj.name.Equals("dionysusleaning"))
        {
            return "Statue of Dionysus Leaning on a Woman";
        }
        else if (obj.name.Equals("woman2ndcent"))
        {
            return "Statue of a Roman Woman (2nd Century A.D.)";
        }
        else if (obj.name.Equals("hadrianbust"))
        {
            return "Bust of Hadrian";
        }
        else if (obj.name.Equals("ecstacystteresa"))
        {
            return "The Ecstacy of St. Teresa";
        }
        else if (obj.name.Equals("pantheon"))
        {
            return "The Pantheon";
        }
        else if (obj.name.Equals("anchisesandmore"))
        {
            return "Statue of Anchises, Aeneas, and Ascanius";
        }
        else if (obj.name.Equals("david"))
        {
            return "Statue of David";
        }
        else if (obj.name.Equals("rapeofproserpina"))
        {
            return "The Rape of Proserpina";
        }
        else if (obj.name.Equals("apolloanddaphne"))
        {
            return "Statue of Daphne Running from Apollo";
        }
        else if (obj.name.Equals("catmosaic"))
        {
            return "Cat Mosaic";
        }
        else if (obj.name.Equals("dogmosaic"))
        {
            return "Dog Mosaic";
        }
        else if (obj.name.Equals("frescoboscoreale"))
        {
            return "Fresco from Boscoreale";
        }
        else if (obj.name.Equals("frescopompeii"))
        {
            return "Fresco from Pompeii";
        }
        else if (obj.name.Equals("medusa"))
        {
            return "Head of Medusa";
        }
        else if (obj.name.Equals("mithras"))
        {
            return "Statue of Mithras Performing a Tauroctony";
        }
        else if (obj.name.Equals("nerobust"))
        {
            return "Bust of Nero";
        }
        else if (obj.name.Equals("serapisbust"))
        {
            return "Bust of Serapis";
        }
        else if (obj.name.Equals("templeofvesta"))
        {
            return "Temple of Vesta";
        }
        else if (obj.name.Equals("fiumifountain"))
        {
            return "The Fiumi Fountain";
        }
        else
        {
            return null;
        }
    }

    private int getIndicatorCount()
    {
        int tempcount = 0;
        if (bomb.IsIndicatorOn("NSA"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("NSA"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("MSA"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("MSA"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("CAR"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("CAR"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("SND"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("SND"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("IND"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("IND"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("CLR"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("CLR"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("SIG"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("SIG"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("TRN"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("TRN"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("FRQ"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("FRQ"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("FRK"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("FRK"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOn("BOB"))
        {
            tempcount++;
        }
        if (bomb.IsIndicatorOff("BOB"))
        {
            tempcount++;
        }
        return tempcount;
    }

    private float reCalcPosition(bool rule1, float num1, float num2, float num3, float num4)
    {
        float tempanswer;
        Debug.LogFormat("[Equations X #{0}] Rule 3 is now true! Recalculating answer...", moduleId);
        if (rule1 == true)
        {
            tempanswer = (num1 * Mathf.Sin(((num2 * num3) + num4) * ((Mathf.PI) / 180))) + 21;
            Debug.LogFormat("[Equations X #{0}] New Equation: (num1 * sin((num2 * num3) + num4)) + 21", moduleId);
            Debug.LogFormat("[Equations X #{0}] With number substitutions: ({1} * sin(({2} * {3}) + {4})) + 21", moduleId, num1, num2, num3, num4);
        }
        else
        {
            tempanswer = num1 * Mathf.Sin(((num2 * num3) + num4) * ((Mathf.PI) / 180));
            Debug.LogFormat("[Equations X #{0}] New Equation: num1 * sin((num2 * num3) + num4)", moduleId);
            Debug.LogFormat("[Equations X #{0}] With number substitutions: {1} * sin(({2} * {3}) + {4})", moduleId, num1, num2, num3, num4);
        }
        return tempanswer;
    }

    private int getWidgetCount()
    {
        int tempcount = 0;
        tempcount += bomb.GetBatteryHolderCount();
        tempcount += bomb.GetPortPlateCount();
        tempcount += getIndicatorCount();
        return tempcount;
    }

    private bool bombHasModule(string name)
    {
        List<string> modules = bomb.GetModuleNames();
        foreach(string mod in modules)
        {
            if (mod.EqualsIgnoreCase(name))
            {
                return true;
            }
        }
        return false;
    }

    private bool serialHasOdd()
    {
        string serial = bomb.GetSerialNumber();
        if (serial.Contains("1") || serial.Contains("3") || serial.Contains("5") || serial.Contains("7") || serial.Contains("9"))
        {
            return true;
        }
        return false;
    }

    private bool serialHasVowels()
    {
        string serial = bomb.GetSerialNumber();
        if (serial.Contains("A") || serial.Contains("E") || serial.Contains("I") || serial.Contains("O") || serial.Contains("U"))
        {
            return true;
        }
        return false;
    }

    private bool isAnyPlateEmpty()
    {
        foreach(string[] plateports in bomb.GetPortPlates())
        {
            if(plateports.Length == 0)
            {
                return true;
            }
        }
        return false;
    }

    private string randomCheer()
    {
        int cheernum = UnityEngine.Random.RandomRange(0, 4);
        return cheers[cheernum];
    }

    private int randomVictory()
    {
        int cheernum = UnityEngine.Random.RandomRange(0, 3);
        return cheernum;
    }

    //twitch plays
#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} cycle [Cycles through all pieces on the module] | !{0} press 2 4 5 [Presses the pieces in the specified order. In this case the 2nd piece, 4th piece, and 5th piece]";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        string[] parameters = command.Split(' ');
        foreach (string param in parameters)
        {
            yield return null;
            if (param.Equals("cycle"))
            {
                int amount = 0;
                while(amount < 6)
                {
                    buttons[0].OnInteract();
                    amount++;
                    yield return new WaitForSeconds(2.0f);
                }
                break;
            }
            else if (param.Equals("press") && !(parameters.Length <= 1))
            {
                foreach (string para in parameters)
                {
                    if(para != "press")
                    {
                        int nextpress = 0;
                        int.TryParse(para, out nextpress);
                        int checker = nextpress - (currentselect+1);
                        if(checker >= 3){
                            for(int i = 0; i < 6-checker; i++)
                            {
                                buttons[1].OnInteract();
                                yield return new WaitForSeconds(0.25f);
                            }
                            buttons[2].OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                        else if (checker > 0 && checker < 3){
                            for (int i = 0; i < checker; i++)
                            {
                                buttons[0].OnInteract();
                                yield return new WaitForSeconds(0.25f);
                            }
                            buttons[2].OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                        else if (checker == 0)
                        {
                            buttons[2].OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                        else if (checker > -3 && checker < 0)
                        {
                            for (int i = 0; i < Mathf.Abs(checker); i++)
                            {
                                buttons[1].OnInteract();
                                yield return new WaitForSeconds(0.25f);
                            }
                            buttons[2].OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                        else if (checker <= -3)
                        {
                            for (int i = 0; i < 6+checker; i++)
                            {
                                buttons[0].OnInteract();
                                yield return new WaitForSeconds(0.25f);
                            }
                            buttons[2].OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                }
                break;
            }
            else
            {
                break;
            }
        }
    }
}
