using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameCustomEngine.Core
{
    public abstract class GameComponent
    {
        public GameObject gameObject = null;
        public bool enabled = true;
        public bool visible = true;

        public GameComponent() { }

        public GameComponent(GameObject go)
        {
            this.gameObject = go;
        }     

        public abstract void Init();
        public abstract void Update(GameTime gt);
        public abstract void Draw(GameTime gt, SpriteBatch spriteBatch);
        public abstract void Destroy();
    }
}
