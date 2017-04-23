using UnityEngine;
using System.Collections;

public class ControllerBall : MonoBehaviour
{
    public Vector3          vDirection;
    public float            fSpeed;
    public GameObject       goParticleBlock;
    public ParticleSystem   psSheets;
    public GameObject       goPanelGameOver;

    // Use this for initialization
    void Start ()
    {
        vDirection.Normalize();
        goPanelGameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, Time.deltaTime * -15)); 
        MovimentBall();
    }

    private void MovimentBall()
    {
        transform.position += vDirection * fSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2         vNormal = collision.contacts[0].normal;
        Plataform       plataform = collision.transform.GetComponent<Plataform>();
        GenaratorEdges  genaratorEdges = collision.transform.GetComponent<GenaratorEdges>();
        bool            bCollisionInvalid = false;
        Vector2 normal = Vector2.zero;
        foreach (ContactPoint2D c in collision.contacts)
        {
            normal += c.normal;
        }
        normal /= collision.contacts.Length;
        normal.Normalize();

        if (plataform != null)
        {
            if(vNormal != Vector2.up)
            {
                bCollisionInvalid = true;
            }
            else
            {
                //ManagerGame.iPonts++;
                psSheets.Play();
            }
        }
        else if(genaratorEdges != null)
        {
            if(vNormal == Vector2.up)
            {
                bCollisionInvalid = true;
            }
        }
        else
        {
            bCollisionInvalid = false;

            Bounds bordasColisor = collision.transform.GetComponent<SpriteRenderer>().bounds;
            Vector3 positionCreator = new Vector3(collision.transform.position.x + bordasColisor.extents.x, collision.transform.position.y - bordasColisor.extents.y, collision.transform.position.z);

            GameObject particles = (GameObject)Instantiate(goParticleBlock, positionCreator, Quaternion.identity);
            ParticleSystem componentParticles = particles.GetComponent<ParticleSystem>();
            Destroy(particles, componentParticles.duration + componentParticles.startLifetime);
            Destroy(collision.gameObject);
            ManagerGame.iNumberBlocksDestroyed++;
        }

        if (!bCollisionInvalid)
        {
            vDirection = Vector2.Reflect(vDirection, vNormal);
            vDirection.Normalize();
        }
        else
        {
            ManagerGame.managerGame.GameOver(goPanelGameOver);
        }
    }
}
