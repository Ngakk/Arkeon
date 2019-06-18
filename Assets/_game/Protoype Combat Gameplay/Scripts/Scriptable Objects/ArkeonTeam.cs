using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonTeam", menuName = "Arkeon Creature/Arkeon Team", order = 0)]
    public class ArkeonTeam : ScriptableObject
    {
        public List<ArkeonInstance> lightBook = new List<ArkeonInstance>();
        public List<ArkeonInstance> darkBook = new List<ArkeonInstance>();
        public List<ArkeonInstance> natureBook = new List<ArkeonInstance>();

        public int Count {
            get { return (lightBook.Count + darkBook.Count + natureBook.Count); }
            private set {  }
        }

        public ArkeonInstance this[int key]
        {
            get
            {
                return GetArkeon(key);
            }
            set
            {
                SetArkeon(key, value);
            }
        }

        private ArkeonInstance GetArkeon(int _key)
        {
            List<List<ArkeonInstance>> books = new List<List<ArkeonInstance>>();
            books.Add(lightBook);
            books.Add(darkBook);
            books.Add(natureBook);

            int counter = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < books[i].Count; j++)
                {
                    if(counter == _key)
                    {
                        return books[i][j];
                    }
                    counter++;
                }
            }

            Debug.LogError("You are trying to access an index that doesn't exist");
            return null;
        }

        private void SetArkeon(int _key, ArkeonInstance _instance)
        {
            List<List<ArkeonInstance>> books = new List<List<ArkeonInstance>>();
            books.Add(lightBook);
            books.Add(darkBook);
            books.Add(natureBook);

            int counter = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < books[i].Count; j++)
                {
                    if(counter == _key)
                    {
                        books[i][j] = _instance;
                        return;
                    }
                    counter++;
                }
            }

            Debug.LogError("You are trying to access an index that doesn't exist");
        }
    }
}
