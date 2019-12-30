using Battle.BattleMap;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Map
{
    public class MenuCell : MonoBehaviour
    {
        private Position p;
        private CellContent c;
        private Color BasicColor = Color.white;

        public CellContent C
        {
            get => c;
            set
            {
                c = value;
                RefreshImage();
            }
        }

        private void OnMouseEnter()
        {
            ChangeColor(Color.green);
        }

        private void OnMouseExit()
        {
            ChangeColor(BasicColor);
        }

        private void ChangeColor(Color c)
        {
            transform.GetChild(0).GetComponent<Image>().color = c;
        }

        private void OnMouseDown()
        {
            ChangeColor(Color.red);
            if (c == CellContent.FREE)
            {
                c = CellContent.STONE;
            }
            else if (c == CellContent.STONE)
            {
                c = CellContent.FREE;
            }
            RefreshImage();
        }

        public void RefreshImage()
        {
            Sprite cur;
            if (c == CellContent.FREE)
            {
                cur = Resources.Load<Sprite>("grass");
            }
            else
            {
                cur = Resources.Load<Sprite>("stone");
            }

            transform.GetChild(0).GetComponent<Image>().sprite = cur;
        }

        public void fill(CellContent content)
        {
            c = content;
            Sprite cur;
            if (c == CellContent.STONE)
            {
                cur = Resources.Load<Sprite>("stone");
            }
            else
            {
                cur = Resources.Load<Sprite>("grass");
            }

            transform.GetChild(0).GetComponent<Image>().sprite = cur;
        }

        private void OnMouseUp()
        {
            ChangeColor(BasicColor);
        }
    }
}