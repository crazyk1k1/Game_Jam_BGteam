using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{

    public Text creditText;
    public GameObject fond;
    public GameObject fonduEnter;
    public GameObject fonduLeave;
    public Animator animator;
    public float timer;
    public float timerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creditText.rectTransform.position += Vector3.up / 6;

        timer += 1 * Time.deltaTime;

        if (timer >= 3)
        {
            Destroy(fonduEnter);
        }

        if (timer >= 100)
        {
            fonduLeave.SetActive(true);
        }

        if (timer >= 80)
        {
            animator.SetBool("CanOut", true);
            timerAnimator += 1 * Time.deltaTime;
            if(timerAnimator >= 3)
            {
                Destroy(fond);
                Destroy(creditText);
            }
        }
    }
}
