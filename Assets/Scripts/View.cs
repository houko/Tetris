using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：视图
*/
public class View : MonoBehaviour
{
    private RectTransform logoName;

    private RectTransform menUI;

    private void Start()
    {
        logoName = transform.Find("Canvas/Logo") as RectTransform;
        menUI = transform.Find("Canvas/MenuUI") as RectTransform;
    }


    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(420, 0.5f);
        menUI.gameObject.SetActive(true);
        menUI.DOAnchorPosY(76.5f, 0.5f);
    }
}