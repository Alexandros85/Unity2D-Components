﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using Matcha.Game.Tweens;


public class DisplayWeaponTitle : BaseBehaviour
{
    private Text textComponent;

    void FadeInText()
    {
        // fade to zero instantly, then fade up slowly
        MTween.FadeOut(textComponent, 0, 0);
        MTween.FadeIn(textComponent, HUD_FADE_IN_AFTER, HUD_TIME_TO_FADE);
    }

    void OnInitEquippedWeapon(GameObject weapon)
    {
        textComponent = gameObject.GetComponent<Text>();
        textComponent.text = weapon.GetComponent<Weapon>().title;
        textComponent.DOKill();
        FadeInText();
    }

    void OnChangeEquippedWeapon(GameObject newWeapon)
    {
        textComponent.text = newWeapon.GetComponent<Weapon>().title;

        // MTween.DisplayScore(gameObject, textComponent);
    }

    void OnFadeHud(bool status)
    {
        MTween.FadeOut(textComponent, HUD_FADE_OUT_AFTER, HUD_TIME_TO_FADE);
    }

    void OnEnable()
    {
        Messenger.AddListener<GameObject>("init equipped weapon", OnInitEquippedWeapon);
        Messenger.AddListener<GameObject>("new equipped weapon", OnInitEquippedWeapon);
        // Messenger.AddListener<GameObject>("change equipped weapon", OnChangeEquippedWeapon);
        Messenger.AddListener<bool>("fade hud", OnFadeHud);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<GameObject>("init equipped weapon", OnInitEquippedWeapon);
        Messenger.RemoveListener<GameObject>("new equipped weapon", OnInitEquippedWeapon);
        // Messenger.RemoveListener<GameObject>("change equipped weapon", OnChangeEquippedWeapon);
        Messenger.RemoveListener<bool>("fade hud", OnFadeHud);
    }
}