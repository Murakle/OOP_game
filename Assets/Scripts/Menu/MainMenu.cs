using System;
using System.IO;
using Battle.BattleMap;
using Core.Army;
using Menu.Map;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject M;
        private CellContent[,] m_map;
        private Core.Army.Army a1 = new Core.Army.Army();
        private Core.Army.Army a2 = new Core.Army.Army();

        private void Awake()
        {
            m_map = new CellContent[8, 14];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    m_map[i, j] = CellContent.FREE;
                }
            }
        }

        public void SetMap()
        {
            M.transform.GetChild(2).gameObject.SetActive(true);
            M.transform.GetChild(1).gameObject.SetActive(false);
        }

        public void SetArmy()
        {
            M.transform.GetChild(3).gameObject.SetActive(true);
            M.transform.GetChild(1).gameObject.SetActive(false);
        }

        public void Exit()
        {
            Application.Quit(0);
        }

        public void Begin()
        {
            string map = "";
            string army1 = "";
            string army2 = "";
            int hh = m_map.GetUpperBound(0) + 1;
            int ww = m_map.GetUpperBound(1) + 1;
            map = "" + hh + " " + ww + " ";
            for (int i = 0; i < hh; i++)
            {
                for (int j = 0; j < ww; j++)
                {
                    map += "" + (m_map[i, j] == CellContent.FREE ? 0 : 1);
                }
            }

            army1 = a1.ToFile();
            army2 = a2.ToFile();
            PlayerPrefs.SetString("Map", map);
            PlayerPrefs.SetString("Army1", army1);
            PlayerPrefs.SetString("Army2", army2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Battle");
        }

        public void MapSetter(CellContent[,] res)
        {
            m_map = res;
        }

        public void ArmySetter(Core.Army.Army a1, Core.Army.Army a2)
        {
            this.a1 = a1;
            this.a2 = a2;
        }
    }
}