using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseDoor : MonoBehaviour
    {
        public Animator animator;
        public string openingAnimation;
        public string closingAnimation;
        public string lockedAnimation;
        public bool isOpen;
        public bool isLocked;
        public string openingMessege;
        public string closingMessage;
        public string lockedMessage;
        public AudioSource aSource;
        public AudioClip openclick;
        public AudioClip lockedClick;

        void Start()
        {
            if (!animator)
            {
                try
                {
                    animator = GetComponent<Animator>();
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
            isOpen = false;
            // Set defaults if not set
            openingAnimation = openingAnimation == "" ? "Opening" : openingAnimation;
            closingAnimation = closingAnimation == "" ? "Closing" : closingAnimation;
            lockedAnimation = lockedAnimation == "" ? "Locked" : lockedAnimation;
            openingMessege = openingMessege == "" ? "You are opening the door." : openingMessege;
            closingMessage = closingMessage == "" ? "You are closing the door." : closingMessage;
            lockedMessage = lockedMessage == "" ? "This door is locked." : lockedMessage;
            aSource.volume = .33f;
        }

        public void unlock()
        {
            isLocked = false;
        }

        void OnMouseOver()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!isOpen)
                {
                    if (isLocked)
                    {
                        StartCoroutine(locked());
                    }
                    else
                    {
                        StartCoroutine(opening());
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(closing());
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print(openingMessege);
            animator.Play(openingAnimation);
            isOpen = true;
            aSource.PlayOneShot(openclick);
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print(closingMessage);
            animator.Play(closingAnimation);
            isOpen = false;
            aSource.PlayOneShot(openclick);
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator locked()
        {
            print(lockedMessage);
            GameManager.Instance.player.GetComponent<CanvasController>().updatedText(lockedMessage);
            aSource.PlayOneShot(lockedClick);
            yield return new WaitForSeconds(2.5f);
        }
    }
}