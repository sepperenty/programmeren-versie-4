using UnityEngine;
using System.Collections;

    //Hier staan alle strings die worden gebruiket in de klassen, static omdat je hier zoiszo aankan, zonder eerst de klasse aan te maken
public static class DestroyedCityConstants
{

    //spider animations.
    public const string IDLE_ANIMATION = "Idle";
    public const string ATTACK_ANIMATION = "Attack";
    public const string DEATH_ANIMATION = "Death";
    public const string WALK_ANIMATION = "Walk";

    //different tags
    public const string SPIDER_TAG = "spider";
    public const string MINE_TAG = "mine";
    public const string TERRAIN_TAG = "terrain";
    public const string PLAYER_TAG = "Player";
    public const string WRACK_TAG = "Wrack";

    //Methods to call.
    public const string HIT_BY_ROCKET = "HitByRocket";
    public const string HIT_BY_SPIDER = "HitBySpider";
    public const string HIT_BY_BULLET = "HitByBullet";

    public const string START_SCENE = "StartMenu";

    public const string PLAYER = "Player";
}
