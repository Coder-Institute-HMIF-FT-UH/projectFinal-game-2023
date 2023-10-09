/*
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Map
{
    public enum NodeStates
    {
        Locked,     // Status node terkunci
        Visited,    // Status node sudah dikunjungi
        Attainable  // Status node dapat dicapai
    }
}

namespace Map
{
    public class MapNode : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public SpriteRenderer sr;                  // Komponen SpriteRenderer
        public Image image;                         // Komponen Image
        public SpriteRenderer visitedCircle;        // Komponen SpriteRenderer untuk lingkaran yang menunjukkan node yang sudah dikunjungi
        public Image circleImage;                   // Komponen Image untuk lingkaran yang menunjukkan node yang sudah dikunjungi
        public Image visitedCircleImage;            // Komponen Image untuk efek swirl ketika node dikunjungi

        public Node Node { get; private set; }      // Data node terkait
        public NodeBlueprint Blueprint { get; private set; }  // Blueprint node terkait

        private float initialScale;                 // Skala awal objek
        private const float HoverScaleFactor = 1.2f;  // Faktor perbesaran saat kursor mouse di atas node
        private float mouseDownTime;                // Waktu ketika tombol mouse ditekan

        private const float MaxClickDuration = 0.5f;  // Durasi maksimal untuk menganggap klik mouse sebagai seleksi

        // Method untuk menginisialisasi node dengan data dan blueprint
        public void SetUp(Node node, NodeBlueprint blueprint)
        {
            Node = node;
            Blueprint = blueprint;
            if (sr != null) sr.sprite = blueprint.sprite;
            if (image != null) image.sprite = blueprint.sprite;
            if (node.nodeType == NodeType.Boss) transform.localScale *= 1.5f;
            if (sr != null) initialScale = sr.transform.localScale.x;
            if (image != null) initialScale = image.transform.localScale.x;

            if (visitedCircle != null)
            {
                visitedCircle.color = MapView.Instance.visitedColor;
                visitedCircle.gameObject.SetActive(false);
            }

            if (circleImage != null)
            {
                circleImage.color = MapView.Instance.visitedColor;
                circleImage.gameObject.SetActive(false);
            }

            SetState(NodeStates.Locked);
        }

        // Method untuk mengatur status node
        public void SetState(NodeStates state)
        {
            if (visitedCircle != null) visitedCircle.gameObject.SetActive(false);
            if (circleImage != null) circleImage.gameObject.SetActive(false);

            switch (state)
            {
                case NodeStates.Locked:
                    if (sr != null)
                    {
                        sr.DOKill();
                        sr.color = MapView.Instance.lockedColor;
                    }

                    if (image != null)
                    {
                        image.DOKill();
                        image.color = MapView.Instance.lockedColor;
                    }

                    break;
                case NodeStates.Visited:
                    if (sr != null)
                    {
                        sr.DOKill();
                        sr.color = MapView.Instance.visitedColor;
                    }

                    if (image != null)
                    {
                        image.DOKill();
                        image.color = MapView.Instance.visitedColor;
                    }

                    if (visitedCircle != null) visitedCircle.gameObject.SetActive(true);
                    if (circleImage != null) circleImage.gameObject.SetActive(true);
                    break;
                case NodeStates.Attainable:
                    // Memulai efek pulsating dari warna locked ke visited:
                    if (sr != null)
                    {
                        sr.color = MapView.Instance.lockedColor;
                        sr.DOKill();
                        sr.DOColor(MapView.Instance.visitedColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
                    }

                    if (image != null)
                    {
                        image.color = MapView.Instance.lockedColor;
                        image.DOKill();
                        image.DOColor(MapView.Instance.visitedColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        // Method yang dipanggil saat kursor mouse memasuki node
        public void OnPointerEnter(PointerEventData data)
        {
            if (sr != null)
            {
                sr.transform.DOKill();
                sr.transform.DOScale(initialScale * HoverScaleFactor, 0.3f);
            }

            if (image != null)
            {
                image.transform.DOKill();
                image.transform.DOScale(initialScale * HoverScaleFactor, 0.3f);
            }
        }

        // Method yang dipanggil saat kursor mouse keluar dari node
        public void OnPointerExit(PointerEventData data)
        {
            if (sr != null)
            {
                sr.transform.DOKill();
                sr.transform.DOScale(initialScale, 0.3f);
            }

            if (image != null)
            {
                image.transform.DOKill();
                image.transform.DOScale(initialScale, 0.3f);
            }
        }

        // Method yang dipanggil saat tombol mouse ditekan pada node
        public void OnPointerDown(PointerEventData data)
        {
            mouseDownTime = Time.time;
        }

        // Method yang dipanggil saat tombol mouse dilepas dari node
        public void OnPointerUp(PointerEventData data)
        {
            if (Time.time - mouseDownTime < MaxClickDuration)
            {
                // Pengguna mengklik node ini:
                MapPlayerTracker.Instance.SelectNode(this);
            }
        }

        
    }
}

*/