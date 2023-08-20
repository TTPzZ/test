using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class JumpPlayer : MonoBehaviour
{
    //cua animation
    public SkeletonAnimation skeleton;
    public AnimationReferenceAsset ready,jump;
    public string owlState;
    //kiem tra su kien hold
    bool move=false;
    //am thanh
    public AudioSource bonx;
    //an hien gameObject
    public GameObject hidePlayer,showSwimming,showbttLeft,showbttRight;
    // Start is called before the first frame update
    void Start()
    {
        setJump(ready, true, 1f);
    }

    // Update is called once per frame

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
        showbttLeft.SetActive(true);
        showbttRight.SetActive(true);
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
        }
    }

}
