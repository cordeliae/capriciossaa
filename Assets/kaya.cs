using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class kaya : MonoBehaviour
{
    public float timeScale;

    [Header("Stats")]
    [SerializeField] float nicotine;
    [SerializeField] float hygiene;
    [SerializeField] float gossip;
    [SerializeField] float bladder;
    [SerializeField] float job;
    //[SerializeField] float toss;

    [Header("Cosie")]
    public NavMeshAgent Agent;
    public Animator animator;
    public GameObject bladdercostam;
    public GameObject nicotinecostam;
    public GameObject hygienecostam;
    public GameObject gossipcostam;
    public GameObject jobcostam;
    public GameObject tosscostam;
    public GameObject pizza;
    public GameObject pizzaOven;
    public GameObject door;
    public GameObject door2;

    public GameObject paczalka;
    public GameObject paczalka2;
    public GameObject paczalka3;

    bool stopstats = false;

    [Header("slidery")]
    public Slider nicotineslider;
    public Slider hygieneslider;
    public Slider gossipslider;
    public Slider bladderslider;
    public Slider jobslider;


    [Header("Animations")]
    private readonly int IsSitting = Animator.StringToHash("sitting");
    private readonly int IsSmoking = Animator.StringToHash("smoking");
    private readonly int IsWashing = Animator.StringToHash("washing");
    private readonly int IsGossiping = Animator.StringToHash("phonetalk");
    private readonly int IsWorking = Animator.StringToHash("makingpizza");

    private readonly int IsTossing = Animator.StringToHash("pizzatoss");


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            //other.GetComponent<MeshRenderer>().enabled = false;
            door.transform.rotation = Quaternion.Euler(0,90,0);
        }
        if (other.CompareTag("door2"))
        {
            //other.GetComponent<MeshRenderer>().enabled = false;
            door2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("door"))
        {
            //other.GetComponent<MeshRenderer>().enabled = true;
            door.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (other.CompareTag("door2"))
        {
            //other.GetComponent<MeshRenderer>().enabled = false;
            door2.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Statsnotstating()
    {
        bladder -= Time.deltaTime * 0.8f;
        nicotine -= Time.deltaTime * 0.7f;
        hygiene -= Time.deltaTime * 0.8f;
        gossip -= Time.deltaTime * 0.6f;
        job -= Time.deltaTime * 1f;

        nicotineslider.value = nicotine;
        hygieneslider.value = hygiene;
        gossipslider.value = gossip;
        bladderslider.value = bladder;
        jobslider.value = job;

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocity", Agent.velocity.magnitude);
        Time.timeScale = Mathf.Clamp(timeScale, 0.1f, 30f);
        if (stopstats == false)
        {
            Statsnotstating();
        }


        if (bladder < 60)
        {

            Agent.SetDestination(bladdercostam.transform.position);
            if (Vector3.Distance(transform.position, bladdercostam.transform.position) > 0.5f)
            {
                stopstats = false;
            }
            else
            {
                animator.GetBool(IsSitting);
                animator.SetBool(IsSitting, true);
                transform.LookAt(paczalka.transform.position);
                Invoke("bladderAdd", 5f);
                stopstats = true;

            }
        }


        if (nicotine < 70)
        {

            Agent.SetDestination(nicotinecostam.transform.position);
            if (Vector3.Distance(transform.position, nicotinecostam.transform.position) > 0.5f)
            {
                stopstats = false;
            }
            else
            {
                animator.GetBool(IsSmoking);
                animator.SetBool(IsSmoking, true);
                Invoke("smokingAdd", 5f);
                stopstats = true;
            }
        }


        if (hygiene < 70)
        {
            Hygiene();
        }


        if (gossip < 60)
        {

            Agent.SetDestination(gossipcostam.transform.position);
            if (Vector3.Distance(transform.position, gossipcostam.transform.position) > 0.5f)
            {
                stopstats = false;
            }
            else
            {
                animator.GetBool(IsGossiping);
                animator.SetBool(IsGossiping, true);
                Invoke("gossipAdd", 5f);
                stopstats = true;
            }
        }


        if (job < 75)
        {

            Agent.SetDestination(jobcostam.transform.position);
            if (Vector3.Distance(transform.position, jobcostam.transform.position) > 0.5f)
            {
                stopstats = false;
            }
            else
            {
                transform.rotation = jobcostam.transform.rotation;
                animator.GetBool(IsWorking);
                animator.SetBool(IsWorking, true);
                Invoke("workingAdd", 5f);
                stopstats = true;
            }
        }

    }

    void Hygiene()
    {

        Agent.SetDestination(hygienecostam.transform.position);
        if (Vector3.Distance(transform.position, hygienecostam.transform.position) > 0.5f)
        {
            stopstats = false;
        }
        else
        {
            animator.GetBool(IsWashing);
            animator.SetBool(IsWashing, true);
            transform.LookAt(paczalka2.transform.position);
            Invoke("washingAdd", 5f);
            stopstats = true;
        }
    }
    void Toss()
    {
        Agent.SetDestination(tosscostam.transform.position);
        if (Vector3.Distance(transform.position, tosscostam.transform.position) <= 0.5f)
        {
            transform.rotation = tosscostam.transform.rotation;
            animator.GetBool(IsTossing);
            animator.SetBool(IsTossing, true);
            //transform.LookAt(paczalka3.transform.position);
            Invoke("tossAdd", 1.5f);
        }
        //else
        //{

        //}
    }

    void bladderAdd()
    {
        animator.SetBool(IsSitting, false);
        bladder = 100;
        GoIdle();
    }

    void smokingAdd()
    {
        animator.SetBool(IsSmoking, false);
        nicotine = 100;
        GoIdle();
    }

    void washingAdd()
    {
        animator.SetBool(IsWashing, false);
        hygiene = 100;
        GoIdle();
    }

    void gossipAdd()
    {
        animator.SetBool(IsGossiping, false);
        gossip = 100;
        GoIdle();
    }

    void workingAdd()
    {
        animator.SetBool(IsWorking, false);
        job = 100;
        pizza.SetActive(true);
        Toss();
    }

    void tossAdd()
    {
        animator.SetBool(IsTossing, false);
        pizza.SetActive(false);
        pizzaOven.SetActive(true);
        StartCoroutine(pizzacooking());
        GoIdle();
    }
    

    void GoIdle()
    {
        stopstats = false;
    }

    IEnumerator pizzacooking()
    {
        yield return new WaitForSeconds(6f);
        pizzaOven.SetActive(false);
    }
}
