using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class JumpPlayer : MonoBehaviour
{
    public SkeletonAnimation skeleton;
    public AnimationReferenceAsset ready,jump;
    public string owlState;
    bool move=false;
    public AudioSource bonx;
    public GameObject hidePlayer,showSwimming;
    public Rigidbody2D bttHole;

    // Start is called before the first frame update
    void Start()
    {
        setJump(ready, true, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void setJump(AnimationReferenceAsset animation,bool loop,float timeScale)
    {
        //if (animation.name.Equals(owlState))
        //{
        //    return;
        //}
        skeleton.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }
    public void setHideShow()
    {
        hidePlayer.SetActive(false);
        showSwimming.SetActive(true);
        bttHole.gravityScale = 11;
    }

    public void setOwl(string state)
    {
        if(state.Equals("jump"))
        {
            setJump(jump, false, 1f);
        }

    }
    public void Move(bool _move)
    {
        move = _move;
        if (move == true)
        {
            setJump(jump, false, 1f);
            Invoke("setHideShow", 3.3f);
            //Debug.Log("hehe");
        }
        
    }

}
