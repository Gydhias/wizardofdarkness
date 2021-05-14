using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeismicShock : Skill
{
    float buffTimer = 7f;
    public override void ActivatedSkill()
    {
        /*"R�duction de d�g�ts - 75% pendant 7 secondes -> boost la parade
        de base durant l'effet"
        Genre de l'armure de fou en gros quoi
        bref, maintenant brow go playerstats.cs! Oeoe
         */
        PlayerCoroutines.Instance.LaunchRoutine(PlayerStats.Instance.StatBuff(buffTimer,EStatsDebuffs.Defense,75));
        canLaunch = false;
    }
}
