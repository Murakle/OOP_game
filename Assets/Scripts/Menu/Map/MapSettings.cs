using System;
using Battle.BattleMap;
using UnityEngine;

namespace Menu.Map
{
    public class MapSettings : MonoBehaviour
    {
        [SerializeField] private GameObject MM;

//        private CellContent[,] m_content;
        private Transform[,] MenuCells;
        private int w, h;

        [SerializeField] private GameObject CellPrefab;

        public void Start()
        {
            GameObject map = GameObject.FindWithTag("Map");
            h = 8;
            w = 14;
            MenuCells = new Transform[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var cellClone = Instantiate(CellPrefab, map.transform);
                    cellClone.transform.name = "Cell(" + (i + 1) + "," + (j + 1) + ")";
                    cellClone.transform.GetComponent<MenuCell>().fill(CellContent.FREE);
                    MenuCells[i, j] = cellClone.transform;
                }
            }
        }

        public void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MM.SetActive(true);
                CellContent[,] res = new CellContent[h, w];
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        res[i, j] = MenuCells[i, j].GetComponent<MenuCell>().C;
                    }
                }

                MM.GetComponent<MainMenu>().MapSetter(res);
                gameObject.SetActive(false);
            }
        }

        public int H
        {
            get => h;
            set => h = value;
        }

        public int W
        {
            get => w;
            set => w = value;
        }
    }
}