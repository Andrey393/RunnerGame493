using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 45f;

    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private List<Transform> baffList;
    [SerializeField] private Hero player;
    [SerializeField] private Vector3 lastEndPosition;
    [SerializeField] private Vector3 baffPosition;
    public static Vector3 heroSpawnPosition;


    public void Awake ( )
    {
        lastEndPosition = levelPartStart.Find ( "EndPosition" ).position;

    }
    private void Update ( )
    {

        if ( Vector3.Distance ( player.transform.position, lastEndPosition ) < PLAYER_DISTANCE_SPAWN_LEVEL_PART )
        {
            SpawmLevelPart1 ( );

        }
    }
    private void SpawmLevelPart1 ( )
    {
        Transform chosenLevelPart = levelPartList [Random.Range ( 0, levelPartList.Count )];

        GameObject lastLevelPartObject = SpawmLevelPart ( chosenLevelPart, lastEndPosition );
        int i = Random.Range ( 0, 6 );
        if ( i >= 4 )
        {
            int baffNomer = 0;
            if ( Hero.healt < 3 )
            {
                baffNomer = Random.Range ( 0, baffList.Count ); //С аптечкой
            }
            else
            {
                baffNomer = Random.Range ( 1, baffList.Count );//Без аптечкой
            }

            Transform baffElevent = baffList [baffNomer];

            GameObject baffEleventTranform = SpawmBaff ( baffElevent, baffPosition );

            baffEleventTranform.transform.SetParent ( lastLevelPartObject.transform );
        }


    }


    private GameObject SpawmLevelPart ( Transform levelPart, Vector3 spawnPosition )
    {
        Transform levelPartTransofotm = Instantiate ( levelPart, spawnPosition, Quaternion.identity );
        lastEndPosition = levelPartTransofotm.Find ( "EndPosition" ).transform.position;
        baffPosition = levelPartTransofotm.Find ( "Baff" ).position;
        heroSpawnPosition = levelPartTransofotm.Find ( "SpawnHero" ).position;

        GameObject levelPartObject = levelPartTransofotm.gameObject;
        return levelPartObject;
    }

    private GameObject SpawmBaff ( Transform Baff, Vector3 spawnPositionBaff )
    {
        Transform spawmBaffObject = Instantiate ( Baff, spawnPositionBaff, Quaternion.identity );
        GameObject baffObject = spawmBaffObject.gameObject;
        return baffObject;

    }
    private GameObject SpawmHero ( Transform SpawnHero, Vector3 heroSpawnPosition )
    {
        Transform spawmHero = Instantiate ( SpawnHero, heroSpawnPosition, Quaternion.identity );
        GameObject HeroSpawn = spawmHero.gameObject;
        return HeroSpawn;

    }
}