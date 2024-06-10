using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kaya : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float nicotine;
    [SerializeField] float hygiene;
    [SerializeField] float gossip;
    [SerializeField] float bladder;
    [SerializeField] float job;
    [SerializeField] float toss;
    [SerializeField] float bell;

    [Header("Cosie")]
    public NavMeshAgent Agent;
    public Animator animator;
    public GameObject bladdercostam;
    public GameObject nicotinecostam;
    public GameObject hygienecostam;
    public GameObject gossipcostam;
    public GameObject jobcostam;
    public GameObject tosscostam;
    public GameObject bellcostam;
    public GameObject pizza;
    public GameObject pizza2;

    public GameObject paczalka;
    public GameObject paczalka2;

    [Header("Animations")]
    private readonly int IsSitting = Animator.StringToHash("sitting");
    private readonly int IsSmoking = Animator.StringToHash("smoking");
    private readonly int IsWashing = Animator.StringToHash("washing");
    private readonly int IsGossiping = Animator.StringToHash("phonetalk");
    private readonly int IsWorking = Animator.StringToHash("makingpizza");
    private readonly int IsTossing = Animator.StringToHash("pizzatoss");
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Statsnotstating()
    {
        bladder -= Time.deltaTime * 0.5f;
        nicotine -= Time.deltaTime * 0.3f;
        hygiene -= Time.deltaTime * 0.5f;
        gossip -= Time.deltaTime * 0.4f;
        job -= Time.deltaTime * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        Statsnotstating();
       
        if (bladder < 45)
        {
            Agent.SetDestination(bladdercostam.transform.position);
            if (Vector3.Distance(transform.position, bladdercostam.transform.position) > 0.5f)
            {

            }
            else
            {
                animator.GetBool(IsSitting);
                animator.SetBool(IsSitting, true);
                transform.LookAt(paczalka.transform.position);
                Invoke("bladderAdd", 5f);
            }
        }

       
        if (nicotine < 70)
        {
            Agent.SetDestination(nicotinecostam.transform.position);
            if (Vector3.Distance(transform.position, nicotinecostam.transform.position) > 0.5f)
            {

            }
            else
            {
                animator.GetBool(IsSmoking);
                animator.SetBool(IsSmoking, true);
                Invoke("smokingAdd", 5f);
            }
        }

        
        if (hygiene < 70)
        {
            Agent.SetDestination(hygienecostam.transform.position);
            if (Vector3.Distance(transform.position, hygienecostam.transform.position) > 0.5f)
            {

            }
            else
            {
                animator.GetBool(IsWashing);
                animator.SetBool(IsWashing, true);
                transform.LookAt(paczalka2.transform.position);
                Invoke("washingAdd", 5f);
            }
        }

        
        if (gossip < 55)
        {
            Agent.SetDestination(gossipcostam.transform.position);
            if (Vector3.Distance(transform.position, gossipcostam.transform.position) > 0.5f)
            {

            }
            else
            {
                animator.GetBool(IsGossiping);
                animator.SetBool(IsGossiping, true);
                Invoke("gossipAdd", 5f);
            }
        }

        
        if (job < 65)
        {
            Agent.SetDestination(jobcostam.transform.position);
            if (Vector3.Distance(transform.position, jobcostam.transform.position) > 0.5f)
            {

            }
            else
            {
                animator.GetBool(IsWorking);
                animator.SetBool(IsWorking, true);
                Invoke("workingAdd", 5f);
            }
        }
       
    }

    void Toss()
    {
        Agent.SetDestination(tosscostam.transform.position);
        if (Vector3.Distance(transform.position, tosscostam.transform.position) > 0.5f)
        {

        }
        else
        {
            animator.GetBool(IsTossing);
            animator.SetBool(IsTossing, true);
            Invoke("tossAdd", 2f);
        }
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
        toss = 100;
        pizza.SetActive(false);
        pizza2.SetActive(true);
        GoIdle();
    }

    void GoIdle()
    {

    }
}
