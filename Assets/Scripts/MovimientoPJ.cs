using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPJ : MonoBehaviour
{
    public float moviPJ;
    public float distPJ;

    private GameObject player;
    private GameObject[] enemys;

    // Start is called before the first frame update
    void Start()
    {
        moviPJ = 0.7f;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        player = players[0];
    }

    // Update is called once per frame
    void Update()
    {
        //distancia jugador
        float closestDistancePlayer = distanceToPlayer();
        //busca enemigos
        GameObject closestEnemy = distanceToEnemys();
        float closestDistanceEnemy = Vector3.Distance(closestEnemy.transform.position, transform.position);;

        if (closestDistanceEnemy < closestDistancePlayer) //compara las distancias etre pj u jugador
        {
            MoveTowards(closestEnemy);
        }
        else
        {
            MoveTowards(player);
        }
    }


    float distanceToPlayer() //Busca al jugador
    {
        return Vector3.Distance(player.transform.position, transform.position);;
    }

    //calcula distancia entre PJ´s
    GameObject distanceToEnemys() //busca enemigos
    {
        //busca enemigos
        GameObject closest = null;
        float distanceEnemy;
        float closestDistanceEnemy = Mathf.Infinity; //distancia jugador

        foreach ( GameObject enemy in enemys)
        {
            if (enemy != gameObject) // Evitar compararse con sí mismo
            {
                distanceEnemy = Vector3.Distance(enemy.transform.position, transform.position);
                if (distanceEnemy < closestDistanceEnemy)
                {
                    closestDistanceEnemy = distanceEnemy;
                    closest = player;
                }

                float distance = (transform.position - player.transform.position).sqrMagnitude;
            }
        }
        return closest;
    }

    void MoveTowards(GameObject target) //choque con jugadores
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * moviPJ * Time.deltaTime;

        //aplicamos fuerza de empuje
        //Rigidbody rb = enemy.collider.GetComponent<Rigidbody>();
        //rb.AddForce(10, ForceMode.Impulse);

    }
}
