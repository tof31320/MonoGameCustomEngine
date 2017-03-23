using MonoGameCustomEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameCustomEngine.Components
{
    public class Transform : MonoGameCustomEngine.Core.GameComponent
    {
        private Transform _parent = null;
        public Transform parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                {
                    _parent.RemoveChild(this);
                }
                _parent = value;
            }
        }

        private List<Transform> children = new List<Transform>();

        private Vector3 position = Vector3.Zero;
        private Vector3 rotation = Vector3.Zero;
        private Vector3 scale = new Vector3(1f, 1f, 1f);

        public Transform(): base() { }

        public Transform(GameObject go) : base(go) { }

        public List<Transform> GetChildren()
        {
            return children;
        }

        public Transform GetChildAt(int index)
        {
            return this.children[index];
        }

        public void AddChild(Transform child)
        {
            child.parent = this;
        }

        public void RemoveChildAt(int index)
        {
            this.children.RemoveAt(index);
        }

        public void RemoveChild(Transform child)
        {
            this.children.Remove(child);
        }

        public override void Init()
        {
        }        

        public override void Update(GameTime gt)
        {
        }

        public override void Draw(GameTime gt, SpriteBatch spriteBatch)
        {            
        }

        public override void Destroy()
        {
        }
    }
}
