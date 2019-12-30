using System;
using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Unity
{
    public class uBattleUnitsStack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private BattleUnitsStack b;
        private Camera MainCamera;
        private Vector3 offset;

        private void Awake()
        {
            MainCamera = Camera.allCameras[0];
            offset = Vector3.zero;
        }


        public void fill(BattleUnitsStack a1)
        {
            b = a1;

            if (b.getTypeShort() == UnitType.DRUID)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Druid");
            if (b.getTypeShort() == UnitType.ELF)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Elf");
            if (b.getTypeShort() == UnitType.DRAGON)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Dragon");
            if (b.getTypeShort() == UnitType.ANGEL)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Angel");
            if (b.getTypeShort() == UnitType.HYDRA)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Hydra");
            if (b.getTypeShort() == UnitType.SHAMAN)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Shaman");
            if (b.getTypeShort() == UnitType.LICH)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Lich");
            if (b.getTypeShort() == UnitType.TROLL)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Troll");
            if (b.getTypeShort() == UnitType.GRIFON)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Grifon");
            if (b.getTypeShort() == UnitType.BEAR)
                transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/Bear");

            transform.GetChild(1).transform.GetComponent<Text>().text = "" + b.getcCount();
        }

        public void FixedUpdate()
        {
            transform.GetChild(1).transform.GetComponent<Text>().text = "" + b.getcCount();
            if (b.Dead())
            {
                Destroy(gameObject);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
            offset.z = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos + offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
//            Debug.Log("END");
            GameObject map = GameObject.FindWithTag("Map");
            Position res = map.GetComponent<uMap>().ListenToAllCells(b.getcPos());
            map.GetComponent<uMap>().SwapCells(b.getcPos(), res);
            b.Move(res);

            GetComponent<RectTransform>().localPosition = getPos(res);
        }

        public bool Move(Position p)
        {
            GameObject map = GameObject.FindWithTag("Map");
            if (b.canMove(p))
            {
                map.GetComponent<uMap>().SwapCells(b.getcPos(), p);
                b.Move(p);
                GetComponent<RectTransform>().localPosition = getPos(p);
                return true;
            }

            return false;
        }

        public bool Attack(BattleUnitsStack bus)
        {
            if (b.canAttack(bus))
            {
                b.Attack(bus);
                return true;
            }

            return false;
        }

        public bool UseSpell(BattleUnitsStack bus)
        {
            return false;
        }

        public bool UseSpell(Cell cell)
        {
            return false;
        }


        private Vector3 getPos(int i, int j)
        {
            return new Vector3(-715 + j * 110, 495 - (i + 1) * 110, 0);
        }

        private Vector3 getPos(Position p)
        {
            return getPos(p.getX, p.getY);
        }

        public Position getPos()
        {
            return b.getcPos();
        }
    }
}