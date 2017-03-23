using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameCustomEngine.Core
{
    public class GameObject
    {
        private string _name = "GameObject";
        public string Name
        {
            get;
            set;
        }

        private List<GameComponent> components = new List<GameComponent>();

        public void AddComponent(GameComponent cmp)
        {
            cmp.gameObject = this;            
            this.components.Add(cmp);
            cmp.Init();
        }

        public void AddComponent<T>() where T : GameComponent, new()
        {
            GameComponent c = new T();

            this.AddComponent(c);
        }

        public T GetComponent<T>() where T : GameComponent
        {            
            foreach (GameComponent c in this.components)
            {
                if (c is T)
                {
                    return (T) c;
                }
            }
            return default(T);
        }

        public void RemoveComponentAt(int index)
        {
            this.components[index].enabled = false;
            this.components[index].Destroy();

            this.components.RemoveAt(index);
        }

        public void RemoveComponents<T>()
        {
            for(int i = 0; i < this.components.Count; i++)
            {
                if (this.components[i] is T)
                {
                    this.components.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Update(GameTime gt)
        {
            for(int i = 0; i < this.components.Count; i++)
            {
                if (this.components[i].enabled)
                {
                    this.components[i].Update(gt);
                }
            }
        }

        public void Draw(GameTime gt, SpriteBatch spriteBatch)
        {
            for(int i = 0; i < this.components.Count; i++)
            {
                if (this.components[i].enabled && this.components[i].visible)
                {
                    this.components[i].Draw(gt, spriteBatch);
                }
            }
        }
    }
}
